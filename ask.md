#
[2025-01-10T12:54:14.612+08:00_W2-5]
我的項目結構如下:
```
A/
	.gitignore
	.git/
	src/
	B/
		.gitignore
		.git/
		src/
```
能不能把A/B項目合入A項目? 要求保留B的提交歷史

##
是的，您可以将 `A/B` 项目合并到 `A` 项目中，并保留 `B` 的提交历史。为此，您可以使用 Git 的 `subtree` 或 `submodule` 功能，或者通过 `git filter-repo` 工具来实现。以下是使用 `subtree` 的方法：

### 使用 Git Subtree 合并

1. **进入 A 项目目录**：

   ```bash
   cd /path/to/A
   ```

2. **添加 B 项目作为远程仓库**：

   首先，您需要将 `B` 目录添加为一个远程仓库。假设 `B` 是一个 Git 仓库，您可以使用以下命令：

   ```bash
   git remote add B ../B
   ```

3. **获取 B 的提交历史**：

   获取 `B` 的提交历史：

   ```bash
   git fetch B
   ```

4. **合并 B 的内容到 A**：

   使用 `subtree` 合并 `B` 的内容到 `A` 的 `src` 目录中：

   ```bash
   git merge -s subtree B/main --allow-unrelated-histories
   ```

   请注意，您需要将 `main` 替换为 `B` 项目的主分支名称（例如 `master`）。

5. **移动 B 的内容到 A 的 src 目录**：

   如果您希望将 `B` 的内容移动到 `A/src` 目录中，可以执行以下操作：

   ```bash
   mkdir -p src/B
   git mv B/* src/B/
   ```

6. **提交更改**：

   提交合并后的更改：

   ```bash
   git commit -m "Merged B project into A project"
   ```

7. **删除 B 的远程引用（可选）**：

   如果您不再需要 `B` 的远程引用，可以删除它：

   ```bash
   git remote remove B
   ```

### 总结

通过以上步骤，您可以将 `A/B` 项目合并到 `A` 项目中，并保留 `B` 的提交历史。使用 `subtree` 方法可以方便地将一个项目的历史合并到另一个项目中，而不需要复杂的操作。请确保在执行这些操作之前备份重要数据，以防止意外丢失文件。




#
[2025-01-10T13:21:46.722+08:00_W2-5]
git 不动子模块的文件、只是让git不再把它当作子模块
子模塊在./NcXml/
##


#
[2025-02-12T21:54:21.360+08:00_W7-3]
c# windows api 讀寫剪貼板

##
```cs
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RimeLuaAot.Windows
{
	public unsafe class WinClipBoard
	{
		[DllImport("user32.dll")]
		private static extern bool OpenClipboard(IntPtr hWndNewOwner);

		[DllImport("user32.dll")]
		private static extern bool CloseClipboard();

		[DllImport("user32.dll")]
		private static extern bool EmptyClipboard();

		[DllImport("user32.dll")]
		private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

		[DllImport("user32.dll")]
		private static extern IntPtr GetClipboardData(uint uFormat);

		[DllImport("user32.dll")]
		private static extern bool IsClipboardFormatAvailable(uint format);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GlobalLock(IntPtr hMem);

		[DllImport("kernel32.dll")]
		private static extern bool GlobalUnlock(IntPtr hMem);

		private const uint CF_UNICODETEXT = 13; // Unicode 文本格式
		private const uint GMEM_MOVEABLE = 0x0002;

		public static void SetText(string text)
		{
			if (text == null)
				return;

			// 打開剪貼板
			if (!OpenClipboard(IntPtr.Zero))
				return;

			// 清空剪貼板
			EmptyClipboard();

			// 將字符串轉換為 UTF-16（Unicode）
			int size = (text.Length + 1) * sizeof(char); // +1 是為了結尾的空字符
			IntPtr hGlobal = GlobalAlloc(GMEM_MOVEABLE, (UIntPtr)size);
			if (hGlobal == IntPtr.Zero)
			{
				CloseClipboard();
				return;
			}

			IntPtr pGlobal = GlobalLock(hGlobal);
			if (pGlobal == IntPtr.Zero)
			{
				GlobalUnlock(hGlobal);
				CloseClipboard();
				return;
			}

			// 複製字符串到內存
			Marshal.Copy(text.ToCharArray(), 0, pGlobal, text.Length);
			// 添加結尾空字符
			Marshal.WriteInt16(pGlobal, text.Length * sizeof(char), 0);

			// 解鎖內存
			GlobalUnlock(hGlobal);

			// 將內存句柄設置到剪貼板
			SetClipboardData(CF_UNICODETEXT, hGlobal);

			// 關閉剪貼板
			CloseClipboard();
		}

		public static string GetText()
		{
			// 打開剪貼板
			if (!OpenClipboard(IntPtr.Zero))
				return null;

			// 檢查剪貼板是否包含 Unicode 格式
			if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
			{
				CloseClipboard();
				return null;
			}

			// 獲取剪貼板數據
			IntPtr hGlobal = GetClipboardData(CF_UNICODETEXT);
			if (hGlobal == IntPtr.Zero)
			{
				CloseClipboard();
				return null;
			}

			IntPtr pGlobal = GlobalLock(hGlobal);
			if (pGlobal == IntPtr.Zero)
			{
				CloseClipboard();
				return null;
			}

			// 讀取字符數量
			string result = Marshal.PtrToStringUni(pGlobal);

			// 解鎖內存
			GlobalUnlock(hGlobal);

			// 關閉剪貼板
			CloseClipboard();

			return result;
		}
	}
}
```


#
[2025-02-12T22:14:02.664+08:00_W7-3]
c 調用lua api push_string、把自己的堆上的字串傳給lua後、要不要釋放指針?
##
在使用Lua API將字符串從C傳遞到Lua時，一般需要注意內存管理的問題。對於使用`lua_pushstring`或`lua_pushlstring`等函數將字符串推送到Lua的情況，Lua會處理這些字符串的內存。

### 具體情況如下：

1. **使用`lua_pushstring`**：
   - 當你使用`lua_pushstring`將字符串推入Lua堆棧時，Lua會將這個字符串的副本存儲在自己的內部結構中。這意味著你可以在推送字符串後安全地釋放原始字符串指針，因為Lua會處理這些字符串的內存管理。
   - 例如：
     ```c
     const char* myString = "Hello, World!";
     lua_pushstring(L, myString);
     // 這裡可以安全釋放myString，因為Lua已經獲取了它的副本。
     ```

2. **使用`lua_pushlstring`**：
   - 當使用`lua_pushlstring`時，你也同樣可以釋放傳遞的指針，因為Lua會複製指定長度的字符串並將其存儲到堆中。
   - 例如：
     ```c
     const char* myString = "Hello, Lua!";
     lua_pushlstring(L, myString, strlen(myString));
     // 這裡同樣可以釋放myString。
     ```

### 總結：
- 對於使用Lua API的`lua_pushstring`或`lua_pushlstring`，在成功推送字符串後，可以安全地釋放原始字符串的指針。Lua會在其內部保存這些字符串的副本，不會影響原始的內存。



#
[2025-02-12T22:32:02.554+08:00_W7-3]

c#中 項目B通過ProjectReference Include引用項目A、兩個項目輸出類型都是lib、都用AOT編譯。
兩個項目中都有UnmanagedCallersOnly導出的符號。我在項目B中執行dotnet publish ... 編譯、但是分別產出了A.dll和B.dll。能不能把兩個項目的導出的符號放到一個dll裏?


#
[2025-02-13T15:17:14.143+08:00_W7-4]
```cs
[UnmanagedCallersOnly(EntryPoint = nameof(WriteClipBoard_Win), CallConvs = new[] { typeof(CallConvCdecl) })]
	public static i32 WriteClipBoard_Win(Lua_State L){
		try{
			log(1);
			u64 len = 0;
			log(1.1);
			byte* cStr = (byte*)Lua_5_4.luaL_checklstring(L, 1, &len); //TODO free?
			log("len: "+len);
			if(cStr == null){//t
				log("cStr == null");
				return 0;
			}
			log(2);
			var text = CStrUtil.cStrToCsStr(cStr);
			log(3);//+
			if(text != null){
				log(3.1);//-
				WinClipBoard.SetText(text);
				log(3.2);
			}
			return 0;
		}
		catch (System.Exception e){
			log("error:");
			log(e);
		}
		log(4);
		return 0;
	}

	static zero log(object info){
		File.AppendAllText("D:/Program Files/Rime/User_Data/TswG_log1", info+"\n");
		return 0;
	}
```
爲甚麼日誌中只看到輸出了1和1.1?  其他甚麼也沒有了. log(2)的輸出也沒看到、也沒有報錯信息、程序也沒有崩潰現象

## ds
好的，我需要分析用户提供的C#代码，为什么日志中只输出了1和1.1，而没有后续的日志记录，也没有报错信息，程序也没有崩溃。首先，我需要仔细阅读代码，理解其结构和可能的问题点。

首先，代码是一个静态方法WriteClipBoard_Win，使用了UnmanagedCallersOnly特性，这意味着这个方法是被非托管代码调用的，比如通过C或C++等语言。入口点是nameof(WriteClipBoard_Win)，调用约定是Cdecl。这可能涉及到与非托管代码的互操作，需要注意参数传递和异常处理的问题。

方法内部有一个try块，里面调用了几个log函数，然后调用了Lua_5_4.luaL_checklstring来获取一个字符串指针，接着转换到C#字符串，再调用WinClipBoard.SetText方法。如果在任何步骤出现错误，catch块会记录异常，但用户说没有看到报错信息，所以可能异常没有被捕获，或者log函数本身有问题。

日志函数log是静态的，将信息写入文件。用户看到日志中有1和1.1，说明至少log函数在开始部分是正常工作的。问题出在log(2)及后续没有被记录，可能的原因有几个方面：

1. **在调用Lua_5_4.luaL_checklstring时崩溃**：可能在这一行代码中出现了问题，导致程序崩溃，但由于是非托管代码，可能没有触发C#的异常，而是直接崩溃，导致后续代码无法执行，包括日志记录。例如，如果L参数无效，或者Lua_5_4的方法有错误，可能导致访问冲突，进而导致进程终止，此时可能不会有异常被C#捕获，因此catch块不会执行，日志也不会记录到错误信息。

2. **cStr为null的情况**：根据代码，如果cStr为null，会记录"cStr == null"并返回0。但用户没有看到这个日志，说明可能cStr不为null，或者该条件判断没有正确触发。需要检查Lua_5_4.luaL_checklstring的行为，是否在参数无效时返回null，或者抛出异常。例如，如果luaL_checklstring在参数无效时抛出错误，而由于这是非托管代码，可能直接导致程序终止，而不是返回null，这时候C#代码无法捕获该异常，因为它是通过Lua的机制抛出的，而不是C#异常。

3. **CStrUtil.cStrToCsStr的问题**：可能在转换指针到字符串时出现问题，比如访问了无效的内存地址，导致崩溃。同样，如果是在非托管代码中发生访问冲突，C#可能无法捕获，导致进程终止，日志无法记录后续信息。

4. **WinClipBoard.SetText的问题**：如果该方法内部抛出异常，但由于某些原因没有被捕获。但代码中有try-catch块，应该会捕获到异常并记录日志。不过用户没有看到错误日志，可能是SetText没有抛出异常，或者异常在非托管代码中被处理，或者log函数在此时出现故障。

5. **log函数本身的问题**：可能在某个点之后，log函数无法写入文件。例如，在第一次或第二次调用后，文件被锁定，导致后续写入失败。需要检查log函数是否有并发访问的问题，或者权限问题，或者路径是否正确。用户提供的路径是"D:/Program Files/Rime/User_Data/TswG_log1"，需要确认该路径是否存在，是否有写入权限，特别是在非托管代码调用时，可能当前工作目录或权限不同。

6. **堆栈溢出或内存损坏**：在非托管代码中发生内存错误，导致进程崩溃，但C#的try-catch无法捕获此类错误，因此日志中不会有记录。

接下来需要逐一排除可能的原因：

- **检查L参数的有效性**：如果Lua_State L是无效的指针，调用luaL_checklstring可能导致崩溃。用户需要确保在调用WriteClipBoard_Win时，传入的L参数是正确的。

- **检查luaL_checklstring的行为**：查阅Lua 5.4的文档，确认luaL_checklstring在参数无效时的行为。如果它调用Lua的error函数，这可能导致Lua跳转（longjmp），绕过C#的异常处理机制，导致程序终止。因为Lua使用setjmp/longjmp来处理错误，这在C#与非托管代码交互时可能导致问题，因为C#的异常处理无法捕获这种跳转，从而导致进程终止，而不会执行后续的C#代码，包括catch块和日志记录。

这一点可能是关键。在Lua的C API中，很多函数（如luaL_checkstring）在参数错误时会调用Lua的error函数，这通常会导致longjmp，直接跳出当前的C/C++代码，返回到Lua的解释器中。在这种情况下，如果在非托管的调用中发生这种情况，可能不会返回到C#代码，导致后续的日志记录无法执行，而整个调用栈被展开，程序可能直接终止或返回到Lua环境中，而不会继续执行C#中的log(2)等代码。

例如，当调用luaL_checklstring时，如果第一个参数（假设是栈索引1的位置）不是一个字符串，Lua会抛出一个错误。在C中，这会通过longjmp来实现，从而绕过C#的异常处理机制。因此，C#中的try-catch块无法捕获这种错误，导致程序的控制流被中断，后续的代码（如log(2)）不会执行，同时进程可能终止或返回到Lua的错误处理中，而不会记录任何C#中的日志。

如果是这种情况，那么当调用luaL_checklstring时，如果参数无效，会导致Lua抛出错误，导致程序跳转，因此C#代码无法继续执行，日志也就停留在1.1之后，没有记录log(2)或者错误信息。

此时，用户需要确保在调用WriteClipBoard_Win时，Lua栈的第一个参数确实是一个字符串。或者，在调用该方法之前，Lua代码必须确保参数正确，否则会导致进程崩溃。

另外，用户提到程序没有崩溃，但日志中只记录到1和1.1，这可能意味着在调用luaL_checklstring时，参数正确，cStr不为null，因此继续执行。但之后可能在CStrUtil.cStrToCsStr转换时出现问题，导致崩溃，但此时是否在非托管代码中？

假设CStrUtil.cStrToCsStr是一个将byte*转换为C#字符串的方法，例如使用Marshal.PtrToStringAnsi或类似的方法。如果cStr指向的地址无效，或者在转换时出现错误，可能会导致访问冲突，从而进程崩溃，同样不会触发C#的异常处理，因此日志无法记录。

另外，检查log函数是否有问题。例如，在log(1)和log(1.1)之后，可能在log(2)时，文件被其他进程锁定，导致写入失败。但用户没有看到任何错误，可能需要检查日志文件是否确实被正确写入，或者在后续的日志调用中是否抛出异常，但由于log函数返回zero（可能应该是void），但代码中定义的是返回zero，可能是一个笔误，正确应该是void。不过C#中没有zero类型，可能用户实际使用的是其他定义，比如返回int，但可能这里存在错误，导致log函数在后续调用中出现问题。

此外，代码中的log函数是写入同一个文件，如果前面的写入成功，但后续的写入失败，可能需要注意文件是否被正确关闭。使用File.AppendAllText通常会在每次写入时打开和关闭文件，所以并发问题可能较小，但如果权限突然变化，或者其他问题，可能导致后续写入失败，但这种情况可能性较低。

总结可能的原因：

1. 在调用luaL_checklstring时，参数无效，导致Lua抛出错误（通过longjmp），导致程序控制流跳出C#方法，无法执行后续代码，包括日志记录，且进程可能终止或返回到Lua的错误处理，而不会触发C#的异常处理。

2. 在转换cStr到C#字符串时发生访问冲突（如无效指针），导致进程崩溃，同样无法记录日志。

3. log函数在后续调用中出现问题，无法写入日志文件，但用户确认1和1.1已写入，说明log函数在开始时工作正常，可能在后续调用中发生问题，但可能性较低。

解决方案的步骤：

- 首先，确保在调用WriteClipBoard_Win时，Lua栈中的第一个参数是有效的字符串。可以通过在Lua代码中添加检查，或者在C#方法中添加更多的日志来验证参数是否正确。

- 修改代码，在调用luaL_checklstring之前，先使用其他Lua API检查参数类型。例如，使用lua_isstring函数来检查参数是否为字符串，如果不是，则记录错误并返回，而不是依赖luaL_checklstring抛出错误，因为这可能触发Lua的longjmp，导致控制流中断。

修改后的代码可能如下：

使用lua_isstring检查参数：

```

if (Lua_5_4.lua_isstring(L, 1) == 0) {

log("参数不是字符串");

return 0;

}

```

然后再调用luaL_checklstring，这样避免触发Lua的错误机制。

- 检查CStrUtil.cStrToCsStr的实现，确保它能正确处理非空的cStr指针，并且转换过程安全。例如，使用Marshal.PtrToStringAnsi或UTF8，根据字符串的实际编码进行处理，并且确保指针指向有效的内存。

- 在log函数中添加异常处理，确保即使写入日志失败，也不会导致程序中断。例如：

```

static void log(object info) {

try {

File.AppendAllText("D:/Program Files/Rime/User_Data/TswG_log1", info + "\n");

} catch (Exception ex) {

// 处理写入失败的情况，例如输出到其他地方

}

}

```

但用户当前的log函数返回zero，可能实际应返回void，这里可能存在代码错误，需要修正。

此外，检查日志文件的路径是否正确，特别是在非托管调用时，当前工作目录可能不同，导致路径无效。使用绝对路径可能更可靠，但需要确保路径存在且有权写入。

另外，考虑在调用非托管代码时，使用更安全的异常处理机制，例如在非托管代码周围添加SEH（结构化异常处理）保护，但这在C#中可能比较复杂。

总结，最可能的原因是luaL_checklstring由于参数无效，触发Lua的错误机制，导致longjmp，跳出C#代码，使得后续日志无法执行。因此，应该在调用luaL_checklstring之前，手动检查参数类型，避免触发Lua的错误处理，从而保持程序的控制流在C#中，确保后续的日志记录和异常处理能够执行。
###
在提供的代码中，日志仅记录到 `1` 和 `1.1` 的原因可能是由于 **Lua C API 的错误处理机制中断了程序的控制流**。以下是详细分析：

1. **非托管代码的错误处理机制**：
   - 当调用 `Lua_5_4.luaL_checklstring(L, 1, &len)` 时，如果 Lua 栈中的第一个参数不是字符串，Lua 会通过 `longjmp` 抛出错误。这种机制会直接跳转回 Lua 的解释器循环，**绕过 C# 的 `try-catch` 块**，导致后续代码（如 `log(2)`）无法执行，且无法记录异常。

2. **验证参数类型**：
   - **解决方案**：在调用 `luaL_checklstring` 前，使用 `lua_isstring` 手动检查参数类型，避免触发 Lua 的错误机制：
     ```csharp
     if (Lua_5_4.lua_isstring(L, 1) == 0) {
         log("参数 1 不是字符串");
         return 0;
     }
     ```
     这样可以确保在参数无效时，控制流仍保持在 C# 中，避免进程意外终止。

3. **检查字符串转换逻辑**：
   - 确保 `CStrUtil.cStrToCsStr` 正确处理 `byte*` 指针，使用如 `Marshal.PtrToStringUTF8` 等方法安全转换，避免访问无效内存。

4. **日志函数的稳健性**：
   - 在 `log` 函数内部添加异常处理，避免写入失败导致程序中断：
     ```csharp
     static void log(object info) {
         try {
             File.AppendAllText("D:/.../TswG_log1", info + "\n");
         } catch {
             // 可选：记录到其他位置或忽略
         }
     }
     ```

5. **路径与权限验证**：
   - 确认日志路径 `D:/Program Files/Rime/User_Data/TswG_log1` 存在且进程有写入权限，避免因权限问题导致后续日志无法记录。

**总结**：主要问题在于 Lua 的 `luaL_checklstring` 在参数无效时触发非托管错误处理，导致程序控制流直接跳转，后续代码无法执行。通过预先检查参数类型并优化错误处理逻辑，可确保日志和异常正常记录。
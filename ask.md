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
= c++ call c\# dll
[2024-11-09T15:50:08.507+08:00]
```cs
	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] // 使用 __cdecl
	public static int add(int a, int b){
		return a + b;
	}
```
以上代碼用AOT編譯後生成了`E:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/aot.dll`、
如何在c++中調用add函數? 我的c++項目用的是cmake
==

=
[2024-11-04T22:11:09.693+08:00]

// KV類繼承IdBlCtUt類、實現了I_KV接口。WordFreq繼承KV類、也實現了I_KV接口、沒有其他任何改動
// ```csharp
// public class WordFreq : KV, I_KV, I_IdBlCtUt{
	
// }
// ```
// 我使用efcore、我想建一張KV表和一張WordFreq表。兩個表結構完全相同。如何配置DbContext?


KV類繼承KVBase。 WordFreq繼承KV類、也實現了I_KV接口、沒有其他任何改動
```csharp
public class WordFreq : KV, I_KV, I_IdBlCtUt{
	
}
```
我使用efcore、我想建一張KV表和一張WordFreq表。兩個表結構完全相同。如何配置DbContext?


= efcore遷移
[2024-11-04T19:42:06.029+08:00]

efcore我已有一個DbContext類。我修改了DbContext類、新建了一張表。如何創建遷移?

==

你修改了 `DbContext` 类并添加了一张新表后，需要执行以下步骤来创建 EF Core 迁移：

**1. 确保已安装必要的包:**

你的项目必须包含 `Microsoft.EntityFrameworkCore.Design` 包。  这通常是作为开发依赖项安装的。  如果没有，请使用 NuGet 包管理器或 .NET CLI 安装它：

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version <你的EF Core版本>
```

替换 `<你的EF Core版本>` 为你项目中使用的 EF Core 版本号。


**2. 添加迁移:**

使用以下命令添加新的迁移：

```bash
dotnet ef migrations add <MigrationName>
```

将 `<MigrationName>` 替换为有意义的迁移名称，例如 `AddMyNewTable`。  这个名称会用于标识你的迁移文件。


**3.  检查迁移文件:**

EF Core 会在你的项目中生成一个 `Migrations` 文件夹，其中包含新的迁移文件。  检查这些文件以确保 EF Core 正确地检测到了你的数据库更改。  如果需要，你可以手动修改这些文件，但通常情况下不需要。


**4. 更新数据库:**

使用以下命令将迁移应用到你的数据库：

```bash
dotnet ef database update
```

这会将你的数据库更新到最新的模式。


**可能遇到的问题和解决方法:**

* **错误信息:**  如果在执行命令时遇到错误，请提供完整的错误信息。  这对于诊断问题至关重要。

* **工作目录:**  确保你的命令行或终端的工作目录指向你的项目目录（包含 `.csproj` 文件的目录）。

* **数据库连接字符串:**  确保你的 `DbContext` 类中正确配置了数据库连接字符串。

* **模型冲突:**  如果你在多个 `DbContext` 中使用相同的实体，可能会导致迁移冲突。  在这种情况下，你需要仔细检查你的模型并解决冲突。

* **复杂的更改:**  对于复杂的数据库更改，你可能需要手动调整生成的迁移文件以确保其正确性。


**示例:**

假设你的 `DbContext` 类名为 `MyDbContext`，你添加了一张名为 `Products` 的表。  那么步骤如下：

1.  确保 `Microsoft.EntityFrameworkCore.Design` 包已安装。

2.  运行 `dotnet ef migrations add AddProductsTable`。

3.  检查生成的迁移文件。

4.  运行 `dotnet ef database update`。


记住替换占位符 `<你的EF Core版本>` 和 `<MigrationName>` 为你的实际值。  如果遇到问题，请提供更多细节，我会尽力帮助你。


=
[2024-11-10T23:23:05.608+08:00]

我的c\#程序是AOT編譯的、我想在c\#代碼中調用`lua.lib`(這是靜態庫、不是dll)中的`lua_pushstring`函數、應該怎麼配置?

==

=
[2024-11-11T23:26:25.635+08:00]

對于沒有c++的純c程序、gcc編譯出的程序可以調msvc的dll嗎

==

可以的,您可以在C程序中調用使用MSVC編譯的DLL中的函數。不過需要注意以下幾點:

1. [1](https://learn.microsoft.com/en-us/cpp/build/dlls-in-visual-cpp?view=msvc-170)DLL中的函數需要使用`__declspec(dllexport)`聲明為導出函數,或者使用.def文件定義導出函數。這樣可以確保C程序能夠正確地找到和調用DLL中的函數。

2. [2](https://cplusplus.com/forum/general/285635/)如果DLL是用C++編譯的,則需要在DLL中使用`extern "C"`來禁用C++的名稱修飾,這樣C程序就能正確地找到和調用DLL中的函數。

3. [3](https://www.quora.com/Is-it-possible-to-call-a-C-dll-library-file-with-C-in-Visual-Studio)在C程序中,可以使用Windows API提供的`LoadLibrary`和`GetProcAddress`函數來動態加載和獲取DLL中的函數指針。

4. [4](https://learn.microsoft.com/en-us/cpp/build/walkthrough-creating-and-using-a-dynamic-link-library-cpp?view=msvc-170)如果您使用Visual Studio IDE來開發,可以參考Microsoft的官方教程,了解如何創建DLL並在C程序中使用。

總之,只要遵循上述幾點,您就可以在使用GCC編譯的C程序中調用使用MSVC編譯的DLL中的函數。關鍵是要正確地聲明和導出DLL中的函數,並在C程序中動態加載和獲取這些函數。


=
[2024-11-11T23:26:25.635+08:00]

g++編譯出的程序可以調msvc(c++)的dll嗎 (調用約定都是cdecl、dll中導出的函數名沒有做命名修飾)

==

=
[2024-11-14T17:08:15.067+08:00]

請你寫一個自定義方法註解`Ex`、使得
```cs
[Ex]
public static extern int myFn();
```
相當於
```cs
[DllImport(
		rimeDllPath
		,EntryPoint = nameof(myFn)
		,CallingConvention = CallingConvention.Cdecl
)]
public static extern int myFn();
```

==

要创建一个自定义特性`Ex`，使其等效于`DllImport`特性，你需要利用反射在运行时动态地加载 DLL 并调用函数。  直接用特性来完全替代`DllImport`是不可能的，因为`DllImport`特性是编译时特性，而自定义特性只能在运行时访问。  因此，下面的代码提供了一个解决方案，它使用`Ex`特性来标记方法，然后在运行时使用反射来模拟`DllImport`的行为。  这需要额外的代码来处理DLL加载和调用。

**1. 自定义特性 `Ex`:**

```csharp
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class ExAttribute : Attribute
{
    public string DllPath { get; set; }
}
```

这个特性包含一个`DllPath`属性，用于指定 DLL 的路径。


**2.  辅助方法用于加载和调用函数:**

```csharp
public static class DllInvoker
{
    public static int InvokeExMethod(MethodInfo methodInfo)
    {
        var exAttribute = methodInfo.GetCustomAttribute<ExAttribute>();
        if (exAttribute == null || string.IsNullOrEmpty(exAttribute.DllPath))
        {
            throw new ArgumentException("ExAttribute must be present and DllPath must be specified.");
        }

        try
        {
            // 加载 DLL
            var assembly = Assembly.LoadFrom(exAttribute.DllPath);

            // 获取函数
            var fn = assembly.GetType(methodInfo.DeclaringType.FullName).GetMethod(methodInfo.Name);
            if (fn == null)
            {
                throw new MissingMethodException(exAttribute.DllPath, methodInfo.Name);
            }

            // 调用函数 (假设函数没有参数)
            return (int)fn.Invoke(null, null); //  这里需要根据实际函数参数进行调整
        }
        catch (Exception ex)
        {
            throw new Exception($"Error invoking method: {ex.Message}", ex);
        }
    }
}
```

这个辅助方法`InvokeExMethod`接受一个`MethodInfo`对象作为参数，它从`Ex`特性中获取DLL路径，加载DLL，找到对应的函数，并调用它。  **注意：**  这段代码假设`myFn`函数没有参数，返回值是整数。  你需要根据你的实际函数签名修改`InvokeExMethod`中的代码。


**3. 使用示例:**

```csharp
[Ex(DllPath = "path/to/your/dll.dll")] // 将 "path/to/your/dll.dll" 替换为你的 DLL 路径
public static extern int myFn();


public static void Main(string[] args)
{
    var methodInfo = typeof(Program).GetMethod(nameof(myFn));
    int result = DllInvoker.InvokeExMethod(methodInfo);
    Console.WriteLine($"Result: {result}");
}
```

记住将 `"path/to/your/dll.dll"` 替换成你的 DLL 的实际路径。  这个例子假设你的 DLL 位于可执行文件相同的目录下，或者你已经设置了正确的路径。


**重要提示:**

* **错误处理:**  上面的代码包含一些基本的错误处理，但你应该添加更健壮的错误处理机制来处理各种异常情况，例如 DLL 加载失败、函数找不到、函数调用失败等。
* **参数和返回值:**  `DllInvoker.InvokeExMethod`  目前只处理没有参数且返回值为整数的函数。  你需要根据你的函数签名修改代码，以正确处理参数和返回值。
* **调用约定:**  `DllImport`特性允许指定调用约定（`CallingConvention`）。  这个例子没有处理调用约定，你需要根据你的 DLL 的要求添加相应的处理逻辑。  这可能需要更复杂的反射操作或使用平台调用 (P/Invoke) 的其他功能。
* **安全性:**  从外部加载 DLL 存在安全风险。  确保你只加载来自可信来源的 DLL。


这个解决方案提供了一个使用自定义特性来简化 DLL 调用过程的方法，但它仍然需要额外的代码来处理运行时的 DLL 加载和函数调用。  它不能完全替代`DllImport`特性，因为`DllImport`特性是在编译时处理的，而这个解决方案是在运行时处理的。 [1](https://learn.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes)[2](https://stackoverflow.com/questions/4879521/how-to-create-a-custom-attribute-in-c-sharp)[3](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/creating-custom-attributes)


== [謬]

你可以创建一个自定义特性 `ExAttribute` 来达到这个目的。这个特性会继承自 `DllImportAttribute`，并提供默认值来简化 `DllImport` 的使用。  以下代码展示了如何实现这个自定义特性以及如何使用它：

```csharp
using System;
using System.Runtime.InteropServices;

// 定义自定义特性 ExAttribute
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ExAttribute : DllImportAttribute
{
    private const string DefaultDllPath = "rimeDllPath"; // 替换成你的默认 DLL 路径
    private const CallingConvention DefaultCallingConvention = CallingConvention.Cdecl;

    public ExAttribute() : base(DefaultDllPath)
    {
        EntryPoint = nameof(myFn); //  假设 myFn 是方法名，需要根据实际情况调整
        CallingConvention = DefaultCallingConvention;
    }
}


public class Example
{
    // 使用自定义特性 ExAttribute
    [Ex]
    public static extern int myFn();


    public static void Main(string[] args)
    {
        //  调用 myFn 方法 (需要确保 rimeDllPath 存在且 myFn 函数已正确声明)
        int result = myFn();
        Console.WriteLine($"myFn returned: {result}");
    }
}
```

**解释:**

1. **`[AttributeUsage(AttributeTargets.Method, Inherited = false)]`**:  这行代码指定了 `ExAttribute` 特性只能应用于方法，并且不能被继承。

2. **`DefaultDllPath` 和 `DefaultCallingConvention`**:  这两个常量定义了默认的 DLL 路径和调用约定。  你需要将 `"rimeDllPath"` 替换成你的实际 DLL 文件路径。

3. **`ExAttribute()` 构造函数**:  这个构造函数调用 `DllImportAttribute` 的基类构造函数，并设置 `EntryPoint` 和 `CallingConvention` 属性的默认值。  `EntryPoint` 使用 `nameof(myFn)` 获取方法名，确保它与 DLL 中的导出函数名匹配。  如果你的导出函数名与方法名不同，你需要手动设置 `EntryPoint` 属性。

4. **`[Ex]`**:  在 `myFn()` 方法声明上方使用 `[Ex]` 属性，这将应用 `ExAttribute` 特性，从而自动设置 `DllImport` 的参数。


**重要注意事项:**

* **DLL 路径:**  确保 `DefaultDllPath`  指向正确的 DLL 文件路径。  这个路径需要根据你的系统配置进行调整。
* **函数名:**  确保 `EntryPoint`  (在本例中是 `nameof(myFn)`) 与你 DLL 中导出的函数名完全一致，包括大小写。
* **调用约定:**  `CallingConvention.Cdecl` 是一个常见的调用约定，但你可能需要根据你的 DLL 使用不同的调用约定 (例如 `CallingConvention.StdCall` 或 `CallingConvention.ThisCall`)。
* **错误处理:**  在实际应用中，你应该添加错误处理机制来处理 DLL 加载失败或函数调用失败的情况。


这个自定义特性简化了 `DllImport` 的使用，但你需要确保你的 DLL 文件正确配置并且函数名和调用约定与你的代码匹配。  否则，程序可能会出现运行时错误。


= c++ 獲取lua傳入的函數
[2024-11-14T17:35:34.555+08:00]

==

在 C++ 中获取 Lua 传入的函数，你需要使用 Lua 的 C API。Lua 函数在 C++ 中表示为一个轻量级用户数据 (light userdata)，它实际上是一个指向 Lua 函数的指针。  你不能直接调用它，而是需要使用 `lua_pcall` 来调用。

以下是如何在 C++ 中获取 Lua 传入的函数，以及如何调用它：


**1.  获取 Lua 函数:**

Lua 函数作为参数传递到你的 C++ 函数时，它会位于 Lua 栈上。你可以使用 `lua_tocfunction` (如果函数是 C 函数) 或 `lua_tofunction` (如果函数是 Lua 函数) 来获取它。  `lua_tofunction` 更通用，适用于 Lua 函数和 C 函数。

```c++
#include <lua.h>
#include <lauxlib.h>
#include <lualib.h>

int myCppFunction(lua_State* L) {
  // 检查参数数量
  if (lua_gettop(L) != 1) {
    return luaL_error(L, "Expected one argument (a function)");
  }

  // 检查参数类型是否为函数
  if (!lua_isfunction(L, 1)) {
    return luaL_error(L, "Argument is not a function");
  }

  // 获取 Lua 函数 (放在栈顶)
  lua_pushvalue(L, 1); // 将函数复制到栈顶，因为 lua_pcall 会消耗栈顶元素
  lua_pushnumber(L, 10); // 传递参数给 Lua 函数

  // 调用 Lua 函数
  int status = lua_pcall(L, 1, 1, 0); // 1 个参数，1 个返回值，0 为错误处理函数

  if (status != 0) {
    std::cerr << "Error calling Lua function: " << lua_tostring(L, -1) << std::endl;
    lua_pop(L, 1); // 清除错误信息
    return luaL_error(L, "Lua function call failed");
  }

  // 获取返回值
  double result = lua_tonumber(L, -1);
  lua_pop(L, 1); // 弹出返回值

  std::cout << "Result from Lua function: " << result << std::endl;
  return 0;
}
```

**2.  注册 C++ 函数到 Lua:**

你需要使用 `lua_register` 或 `lua_pushcfunction` 将你的 C++ 函数注册到 Lua 环境中，以便 Lua 代码可以调用它。

```c++
int main() {
  lua_State* L = luaL_newstate();
  luaL_openlibs(L);

  lua_register(L, "myCppFunction", myCppFunction);

  // ... (运行 Lua 代码) ...

  lua_close(L);
  return 0;
}
```

**3.  Lua 代码示例:**

```lua
function myLuaFunction(x)
  return x * 2
end

result = myCppFunction(myLuaFunction)  -- 调用 C++ 函数，传入 myLuaFunction
print(result)                         -- 打印结果
```

**4.  错误处理:**

*   **参数类型检查:**  使用 `lua_isfunction` 检查参数是否为函数。
*   **`lua_pcall` 返回值:**  检查 `lua_pcall` 的返回值，判断 Lua 函数调用是否成功。  如果失败，`lua_tostring` 可以获取错误信息。
*   **错误处理函数:**  `lua_pcall` 的第四个参数是错误处理函数的索引，可以指定一个函数来处理错误。


**完整的例子:**

```c++
#include <lua.h>
#include <lauxlib.h>
#include <lualib.h>
#include <iostream>

int myCppFunction(lua_State* L) {
    // ... (如上所示的代码) ...
}

int main() {
  lua_State* L = luaL_newstate();
  luaL_openlibs(L);
  lua_register(L, "myCppFunction", myCppFunction);

  if (luaL_dofile(L, "my_script.lua") != 0) {
    std::cerr << "Error loading Lua script: " << lua_tostring(L, -1) << std::endl;
    lua_close(L);
    return 1;
  }

  lua_close(L);
  return 0;
}
```

记住将 `"my_script.lua"` 替换为你的 Lua 脚本文件的名称。  这个例子展示了如何从 Lua 脚本中调用 C++ 函数，并处理潜在的错误。  确保你的 Lua 脚本文件包含一个名为 `myLuaFunction` 的函数。


这个例子假设 Lua 函数只有一个数字参数并返回一个数字。  你需要根据你的 Lua 函数的参数和返回值类型进行相应的调整。  对于更复杂的情况，例如 Lua 函数有多个参数或返回多个值，你需要更仔细地管理 Lua 栈。

= 對于臨時變量 `I_接口 myVar = new 結構體();` myVar是開在棧上還是堆上? 按值傳遞還是引用傳遞?
[2024-11-27T20:24:02.473+08:00]

==

=
[2024-11-28T13:54:32.512+08:00_W48-4]

C\# 流式處理時、有兩種方案:

1 讓數據提供者實現`T getNext(); bool hasNext()`、然後數據處理者調用數據提供者的getNext等方法

2 讓數據處理者實現`int process(T data)`、然後數據提供者提供數據、並調用數據處理者的process等方法

應該怎麼選擇

==

在 C# 流式处理中，选择数据提供者和数据处理者之间交互方式的最佳方案取决于具体的应用场景和优先级。两种方案各有优缺点：

**方案一：数据提供者实现 `T getNext(); bool hasNext()`**

* **优点:**
    * **数据提供者控制流:** 数据提供者完全控制数据的提供节奏，可以根据需要进行缓冲、过滤、转换等操作。这在处理大型数据集或需要复杂数据预处理的情况下非常有用。
    * **更清晰的职责分离:** 数据提供者专注于数据的获取和准备，数据处理者专注于数据的处理逻辑，职责更加清晰。
    * **更好的可测试性:**  可以独立测试数据提供者和数据处理者。

* **缺点:**
    * **数据提供者耦合度高:** 数据提供者需要了解数据处理者的接口，耦合度较高。
    * **处理逻辑分散:** 数据处理逻辑分散在数据提供者和数据处理者中，可能难以维护。


**方案二：数据处理者实现 `int process(T data)`**

* **优点:**
    * **数据提供者更简单:** 数据提供者只需要负责数据的提供，无需关心数据的处理逻辑，实现更简单。
    * **数据处理逻辑集中:** 数据处理逻辑集中在数据处理者中，更容易维护和理解。
    * **更好的扩展性:** 可以更容易地添加新的数据处理者，实现不同的处理逻辑。

* **缺点:**
    * **数据处理者控制流:** 数据处理者对数据的处理节奏有较大的影响，可能导致性能问题。
    * **数据提供者职责不明确:** 数据提供者可能需要承担一些数据处理的职责，职责分离不够清晰。
    * **可测试性较差:**  数据提供者和数据处理者之间的耦合度较高，难以独立测试。


**选择建议:**

* **选择方案一，如果:**
    * 数据量非常大，需要进行复杂的预处理或过滤。
    * 需要对数据提供节奏进行精细控制。
    * 优先考虑职责分离和可测试性。

* **选择方案二，如果:**
    * 数据量相对较小，预处理需求简单。
    * 优先考虑代码简洁性和易维护性。
    * 需要方便地添加新的数据处理逻辑。


**代码示例 (方案一):**

```csharp
// 数据提供者接口
public interface IDataProvider<T>
{
    T GetNext();
    bool HasNext();
}

// 数据处理者接口
public interface IDataProcessor<T>
{
    void Process(T data);
}

// 数据提供者实现
public class FileDataProvider : IDataProvider<string>
{
    // ... 实现 GetNext 和 HasNext 方法 ...
}

// 数据处理者实现
public class DataProcessor : IDataProcessor<string>
{
    public void Process(string data)
    {
        // ... 处理数据 ...
    }
}

// 使用示例
public void ProcessData()
{
    IDataProvider<string> provider = new FileDataProvider();
    IDataProcessor<string> processor = new DataProcessor();

    while (provider.HasNext())
    {
        processor.Process(provider.GetNext());
    }
}
```

**代码示例 (方案二):**

```csharp
// 数据处理者接口
public interface IDataProcessor<T>
{
    int Process(T data);
}

// 数据提供者
public class DataProvider<T>
{
    public void ProvideData(IDataProcessor<T> processor, IEnumerable<T> data)
    {
        foreach (var item in data)
        {
            processor.Process(item);
        }
    }
}

// 数据处理者实现
public class DataProcessor : IDataProcessor<string>
{
    public int Process(string data)
    {
        // ... 处理数据 ...
        return 0; // 返回处理结果
    }
}

// 使用示例
public void ProcessData()
{
    IDataProcessor<string> processor = new DataProcessor();
    DataProvider<string> provider = new DataProvider<string>();
    List<string> data = new List<string>() { "data1", "data2", "data3" };
    provider.ProvideData(processor, data);
}
```

记住，这只是一个简单的示例，实际应用中可能需要考虑更多的因素，例如错误处理、并发处理、性能优化等。  选择哪种方案取决于你的具体需求和权衡。


=
[2024-11-29T23:01:47.561+08:00_W48-5]

```cs
public interface I1<T>{
	int process(T data);
}


public interface I2<T>{
	Func<T,int> process{get;set;}
}
```

當我的接口中只有一個函數時、用哪種寫法好?

==


=
[2024-12-15T15:04:33.259+08:00_W50-7]

```

    /home/tsinswreng/.nuget/packages/microsoft.dotnet.ilcompiler/9.0.0/build/Microsoft.NETCore.Native.Publish.targets(77,5): error : The PrivateSdkAssemblies ItemGroup is required for _ComputeAssembliesToCompileToNative

Build failed with 1 error(s) and 6 warning(s) in 13.5s

tsinswreng@Y7000P:/mnt/e/_code/cli-tools/RimeLuaAot$

```
;

用中文解释

==

这个错误信息是在使用 .NET 9.0.0 版本的 Microsoft.DotNet.ILCompiler 包进行构建时出现的。

具体错误信息如下:

```
/home/tsinswreng/.nuget/packages/microsoft.dotnet.ilcompiler/9.0.0/build/Microsoft.NETCore.Native.Publish.targets(77,5): error : The PrivateSdkAssemblies ItemGroup is required for _ComputeAssembliesToCompileToNative
```

这个错误表示构建过程中缺少一个名为 `PrivateSdkAssemblies` 的 ItemGroup,这个 ItemGroup 是 .NET 9.0.0 版本的 Microsoft.DotNet.ILCompiler 包所需要的。

造成这个问题的可能原因有:

1. 项目配置或引用存在问题,缺少必要的设置或引用。
2. 使用的 .NET SDK 版本与 Microsoft.DotNet.ILCompiler 包的版本不匹配。
3. 项目文件或构建脚本中可能存在问题。

要解决这个问题,可以尝试以下步骤:

1. 检查项目配置和引用,确保正确引用了所需的包和 SDK。
2. 尝试更新 .NET SDK 到最新版本,或使用与 Microsoft.DotNet.ILCompiler 包版本匹配的 SDK。
3. 检查项目文件或构建脚本,确保没有其他问题。
4. 如果问题仍然存在,可以尝试在网上搜索相关的解决方案,或者向相关的社区寻求帮助。

总之,这个错误是由于缺少 .NET 9.0.0 版本的 Microsoft.DotNet.ILCompiler 包所需的 `PrivateSdkAssemblies` ItemGroup 导致的。需要检查项目配置和引用,确保正确使用了匹配的 SDK 和包版本。



=
[2024-12-24T19:45:55.743+08:00_W52-2]

我的c\#項目中有
`global using Str = System.String;`

並且我在代碼中大量使用了Str作爲類型別名。現在我想把Str改成str、應該怎麼做?

==



=
[2024-12-24T20:24:00.400+08:00_W52-2]

c\#中、我想表示函數沒有返回值、用甚麼方案好?

1. 直接用void表示沒有返回值
2. 起一個類型別名叫zero, global using zero = System.Byte; 然後return 0;
3. 起一個類型別名叫zero, global using zero = System.Int32; 然後return 0;
4. 做一個全局唯一對象Unit, 然後返回Unit
5. 返回值類型聲明爲Object, 然後return null;
6. 其他。由你補充

由于void 不能作泛型參數、所以我不是很傾向用void。
幫我出出主意

==

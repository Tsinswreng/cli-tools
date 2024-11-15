// See https://aka.ms/new-console-template for more information
//dotnet publish -c Release -r win-x86
//dumpbin /EXPORTS "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll"
//dumpbin /EXPORTS "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/native/aot.dll"
// dumpbin /EXPORTS "E:/_code/rime-tools/aot/lib/librime-lua5.4/dist/lib/rime.dll"
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.IO;

unsafe class Program {
	public const string rimeDllPath = "D:/ENV/Rime/weasel-0.15.0/rime.dll";
	static void Main(string[] args){
		
		Console.WriteLine("Hello, World!");
		Console.ReadLine();
	}

	static void log(string msg){
		File.AppendAllText("rimeLog.txt", msg + "\n");
	}

	[DllImport(
		rimeDllPath
		,EntryPoint = nameof(lua_pushnumber)
		,CallingConvention = CallingConvention.Cdecl
	)]
	public static extern void lua_pushnumber(IntPtr L, double n);

	[DllImport(
		rimeDllPath
		,EntryPoint = nameof(lua_tonumberx)
		,CallingConvention = CallingConvention.Cdecl
	)]
	public static extern double lua_tonumberx(IntPtr L, int index, int* isNum);



	[UnmanagedCallersOnly(EntryPoint = nameof(lua_add), CallConvs = new[] { typeof(CallConvCdecl) })]
	public static int lua_add(IntPtr L){
		log("lua_add");
		log(L.ToString());
		int isNum;
		var a = lua_tonumberx(L, 1, &isNum);
		log($"a: {a}");
		var b = lua_tonumberx(L, 2, &isNum);
		log($"b: {b}");
		var ans = a + b;
		log($"ans: {ans}");
		lua_pushnumber(L, ans);
		log("lua_pushnumber(L, ans);");
		return 1;
	}

	[UnmanagedCallersOnly(
		CallConvs = new[] { typeof(CallConvCdecl) }
		,EntryPoint = nameof(tsins_add__cdecl) //必寫、否則dll中無佢
	)] // 使用 __cdecl
	public static int tsins_add__cdecl(int a, int b){
		var ans = a + b;
		System.IO.File.WriteAllText(nameof(tsins_add__cdecl), ans.ToString());
		return ans;
	}

	[UnmanagedCallersOnly(
		CallConvs = new[] { typeof(CallConvStdcall) }
		,EntryPoint = nameof(tsins_add__stdcall)
	)] // 使用 __stdcall
	public static int tsins_add__stdcall(int a, int b){
		return a + b;
	}

}

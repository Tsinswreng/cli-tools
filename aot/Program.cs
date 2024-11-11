// See https://aka.ms/new-console-template for more information
//dotnet publish -c Release -r win-x64
//dumpbin /EXPORTS "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll"
// dumpbin /EXPORTS "E:/_code/rime-tools/aot/lib/librime-lua5.4/dist/lib/rime.dll"
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
unsafe class Program {
	public const string rimeDllPath = "E:/_code/rime-tools/aot/lib/librime-lua5.4/dist/lib/rime.dll";
	static void Main(string[] args){

		Console.WriteLine("Hello, World!");
		Console.ReadLine();
	}

	[DllImport(
		rimeDllPath
		,EntryPoint = "lua_pushnumber"
		,CallingConvention = CallingConvention.Cdecl
	)]
	public static extern void lua_pushnumber(IntPtr L, double n);

	[DllImport(
		rimeDllPath
		,EntryPoint = nameof(lua_tonumberx)
		,CallingConvention = CallingConvention.Cdecl
	)]
	public static extern double lua_tonumberx(IntPtr L, int index, int* isNum);

	[UnmanagedCallersOnly(
		CallConvs = new[] { typeof(CallConvCdecl) }
		,EntryPoint = nameof(lua_add)
	)] // 使用 __cdecl
	public static int lua_add(IntPtr L){
		Console.WriteLine("a");
		Console.WriteLine(L);
		int isNum;
		var a = lua_tonumberx(L, 1, &isNum);
		Console.WriteLine("b");
		var b = lua_tonumberx(L, 2, &isNum);
		Console.WriteLine("c");
		var ans = a + b;
		Console.WriteLine("ans: "+ans);
		lua_pushnumber(L, ans);
		Console.WriteLine("d");
		return 1;
	}

	[UnmanagedCallersOnly(
		CallConvs = new[] { typeof(CallConvCdecl) }
		,EntryPoint = "tsins_add__cdecl" //必寫、否則dll中無佢
	)] // 使用 __cdecl
	public static int tsins_add__cdecl(int a, int b){
		return a + b;
	}

	[UnmanagedCallersOnly(
		CallConvs = new[] { typeof(CallConvStdcall) }
		,EntryPoint = "tsins_add__stdcall"
	)] // 使用 __stdcall
	public static int tsins_add__stdcall(int a, int b){
		return a + b;
	}

}


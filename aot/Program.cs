// See https://aka.ms/new-console-template for more information
//dotnet publish -c Release -r win-x64
//dumpbin /EXPORTS "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll"

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
class Program{

static void Main(string[] args){

Console.WriteLine("Hello, World!");
Console.ReadLine();


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


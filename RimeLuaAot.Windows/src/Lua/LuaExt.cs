using Lua_State = System.IntPtr;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static Lua.Lua_5_4;
using System.Globalization;
using RimeLuaAot.Windows;
using RimeLuaAot.Util;
namespace Lua;


unsafe public partial class LuaExt_5_4_Win : LuaExt_5_4{

	[UnmanagedCallersOnly(EntryPoint = nameof(ReadClipBoard_Win), CallConvs = new[] { typeof(CallConvCdecl) })]
	public static i32 ReadClipBoard_Win(Lua_State L){
		var text = WinClipBoard.GetText()??"";
		byte* cStr = CStrUtil.csStrToCStr(text);
		Lua_5_4.lua_pushstring(L, cStr);
		Marshal.FreeHGlobal((IntPtr)cStr);
		return 1;
	}

	[UnmanagedCallersOnly(EntryPoint = nameof(WriteClipBoard_Win), CallConvs = new[] { typeof(CallConvCdecl) })]
	public static i32 WriteClipBoard_Win(Lua_State L){
		var cStr = (byte*)Lua_5_4.lua_tostring(L, 1);
		var text = CStrUtil.cStrToCsStr(cStr);
		if(text != null){
			WinClipBoard.SetText(text);
		}
		return 0;
	}
}
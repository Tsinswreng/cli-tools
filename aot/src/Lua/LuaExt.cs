using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Lua_State = System.IntPtr;
using static Lua.Lua_5_4;
namespace Lua;

unsafe public static class LuaExt_5_4{
	/// <summary>
	/// setTimeout(fn:Function, delay:number):void
	/// </summary>
	/// <param name="L"></param>
	/// <returns></returns>
	// [UnmanagedCallersOnly(EntryPoint = nameof(setTimeout), CallConvs = new[] { typeof(CallConvCdecl) })]
	// public static int setTimeout(Lua_State L){
	// 	if(lua_gettop(L) != 2){
	// 		return 0;
	// 	}

	// 	double delay = lua_tonumber(L, 2);
	// 	return 0;
	// }

	[UnmanagedCallersOnly(EntryPoint = nameof(getUnixTimeMillis), CallConvs = new[] { typeof(CallConvCdecl) })]
	public static int getUnixTimeMillis(Lua_State L){
		i64 ans = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		lua_pushinteger(L, ans);
		return 1;
	}

	
}

/* 
lua能不能把多個函數傳給c++、然後不阻塞線程繼續執行後面的內容。c++先不執行它、等到合適的時機再執行lua傳入的函數?
 */
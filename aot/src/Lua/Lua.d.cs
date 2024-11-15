using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Lua;

using Lua_State = System.IntPtr;

unsafe public class Lua_5_4{
	public const string DllPath = "D:/ENV/Rime/weasel-0.15.0/rime.dll";

	[DllImport(DllPath,EntryPoint = nameof(lua_pushnumber),CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushnumber(Lua_State L, double n);


	[DllImport(DllPath,EntryPoint = nameof(lua_pushnil),CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushnil(Lua_State L);


	[DllImport(DllPath, EntryPoint = nameof(lua_pushinteger), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushinteger(Lua_State L, long n);

	[DllImport(DllPath, EntryPoint = nameof(lua_pushboolean), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushboolean(Lua_State L, int b);

	[DllImport(DllPath, EntryPoint = nameof(lua_pushstring), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushstring(Lua_State L, string s);

	[DllImport(DllPath, EntryPoint = nameof(lua_pushlightuserdata), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushlightuserdata(Lua_State L, IntPtr p);


	[DllImport(DllPath, EntryPoint = nameof(lua_toboolean), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_toboolean(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_isnumber), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_isnumber(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_tonumber), CallingConvention = CallingConvention.Cdecl)]
	public static extern double lua_tonumber(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_tointeger), CallingConvention = CallingConvention.Cdecl)]
	public static extern long lua_tointeger(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_isstring), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_isstring(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_tostring), CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr lua_tostring(Lua_State L, int index);


	/// <summary>
	/// 取 傳ʹ參ʹ數
	/// </summary>
	/// <param name="L"></param>
	/// <returns></returns>	
	[DllImport(DllPath, EntryPoint = nameof(lua_gettop), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_gettop(Lua_State L);

	[DllImport(DllPath, EntryPoint = nameof(lua_settop), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_settop(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_pop), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pop(Lua_State L, int n);

	[DllImport(DllPath, EntryPoint = nameof(lua_pushvalue), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushvalue(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_remove), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_remove(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_insert), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_insert(Lua_State L, int index);

	[DllImport(DllPath, EntryPoint = nameof(lua_replace), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_replace(Lua_State L, int index);


	//  运行Lua代码
	[DllImport(DllPath, EntryPoint = nameof(luaL_dostring), CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaL_dostring(Lua_State L, string s);

	[DllImport(DllPath, EntryPoint = nameof(lua_pcall), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_pcall(Lua_State L, int nargs, int nresults, int errfunc);


	//  错误处理
	// [DllImport(DllPath, EntryPoint = nameof(lua_tostring), CallingConvention = CallingConvention.Cdecl)]
	// public static extern IntPtr lua_tostring(Lua_State L, int index);


	// 状态管理
	[DllImport(DllPath, EntryPoint = nameof(luaL_newstate), CallingConvention = CallingConvention.Cdecl)]
	public static extern Lua_State luaL_newstate();

	[DllImport(DllPath, EntryPoint = nameof(lua_close), CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_close(Lua_State L);



}

/* 
請你根據lua5.4的lua.h中 導出的函數、補充此代碼。用c#寫一遍lua函數的類型聲明
*/

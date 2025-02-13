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
	public static extern void lua_pushstring(Lua_State L, byte* s);

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


	/// <summary>
// lua_tolstring
// [-0, +0, m]

// const char *lua_tolstring (lua_State *L, int index, size_t *len);
// Converts the Lua value at the given index to a C string. If len is not NULL, it sets *len with the string length. The Lua value must be a string or a number; otherwise, the function returns NULL. If the value is a number, then lua_tolstring also changes the actual value in the stack to a string. (This change confuses lua_next when lua_tolstring is applied to keys during a table traversal.)

// lua_tolstring returns a pointer to a string inside the Lua state (see §4.1.3). This string always has a zero ('\0') after its last character (as in C), but can contain other zeros in its body.

// This function can raise memory errors only when converting a number to a string (as then it may create a new string).
	/// </summary>
	/// <param name="L"></param>
	/// <param name="index"></param>
	/// <param name="len"></param>
	/// <returns></returns>
	[DllImport(DllPath, EntryPoint = nameof(lua_tolstring), CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_tolstring(Lua_State L, int index, u64* len);



/// <summary>
// const char *luaL_checklstring (lua_State *L, int arg, size_t *l);
// Checks whether the function argument arg is a string and returns this string; if l is not NULL fills its referent with the string's length.

// This function uses lua_tolstring to get its result, so all conversions and caveats of that function apply here.
//chatGPT4o mini:
// luaL_checklstring 函數返回的是 Lua 中的一個字符串指針，這個指針指向的是 Lua 的內部字符串存儲。
// 在這種情況下，你不需要自己釋放這個字符串。Lua 會自動管理其內部字符串的記憶體，
// 當你完成使用後，字符串會在 Lua 的垃圾回收機制下被適當釋放。
// 簡單來說，當你使用 luaL_checklstring 獲取字符串時，你可以放心使用，無需手動釋放其記憶體。
/// </summary>
/// <param name="L"></param>
/// <param name="index"></param>
/// <param name="len"></param>
/// <returns></returns>
	[DllImport(DllPath, EntryPoint = nameof(luaL_checklstring), CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaL_checklstring(Lua_State L, int index, u64* len);




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

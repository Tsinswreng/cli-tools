Wat = print
--LoadLibraryW
local function main()
	--local dllPath = "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll"
	local dllPath = "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/native/aot.dll"
	local fnName = "lua_add"
	--local fnName = "tsins_add__cdecl"

	--local dllPath = "E:/_code/CSharpAotDllExample/Native-CSharp/CxxDll/CxxDll.dll" -- gcc -- 可導入
	--local dllPath = "E:/_code/CSharpAotDllExample/Native-CSharp/CxxDll/build/Debug/CxxDll.dll" -- msvc -- %1不是有效的win32程序
	-- local fnName = "add_numbers"
	-- local dllPath = "C:/Windows/System32/kernel32.dll"
	-- local fnName = "LoadLibraryW"
	local fn, err = package.loadlib(dllPath, fnName)
	if not fn then
		Wat("Failed to load library")
		Wat(err)
		return
	end
	Wat("Library loaded successfully")

	local ans = fn(1,2)
	Wat(ans)
end


main()
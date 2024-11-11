
local function main()

	local dllPath = "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll"
	local fnName = "lua_add"
	local fn = package.loadlib(dllPath, fnName)
	if not fn then
		print("Failed to load library")
		return
	end

	local ans = fn(3,4)
	print(ans)
end

main()
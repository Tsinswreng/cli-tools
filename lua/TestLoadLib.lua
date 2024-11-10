
local function main()

	local dllPath = "E:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/aot.dll"
	local fnName = "add"
	local fn = package.loadlib(dllPath, fnName)
	if not fn then
		print("Failed to load library")
		return
	end

	local ans = fn(1,2)
	print(ans)
end

main()
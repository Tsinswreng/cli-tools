dotnet publish -c Release -r win-x86

mkdir -p "D:/Program Files/Rime/User_Data/lua/__TswG_lib__/win-x86"
mv "./bin/Release/net9.0/win-x86/native/RimeLuaAot.Windows.dll" "D:/Program Files/Rime/User_Data/lua/__TswG_lib__/win-x86/csrime_win.dll"
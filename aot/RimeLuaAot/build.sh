dotnet publish -c Release -r win-x86
mv "./bin/Release/net9.0/win-x86/native/aot.dll" "D:/Program Files/Rime/User_Data/lua/_lib/csrime.dll"
==

[2024-11-11T23:20:07.099+08:00]


現象:

rime之lua不可 以`package.loadlib`調c\# aot之dll、亦不可調msvc之dll、報錯曰`%1不是有效的win32程序`

本機之lua5.4 可調msvc編譯之dll、亦可調c\# aot編譯之dll、肰叵調g++編譯之dll。

猜想:

小狼毫0.15.0 中之lua環境是gcc編譯厎、本機中獨立ʹ lua5.4環境是msvc編譯厎、二者ABI不兼容

==

[2024-11-12T11:46:58.358+08:00]

rime之lua與獨立lua皆能調`C:/Windows/System32/kernel32.dll`


==

[2024-11-12T23:12:50.081+08:00]

故: 

雖AI曰 未指定產物是32位抑64位旹、于64位ʹ機ʸ默認64位、肰本機ʸʹ mingw gcc版本ˋ只支持編譯出32位ʹ程序、故`cmake -G "Ninja" ..`編譯所得ˋ32位者也、32位與64位不能直ᵈ互調。

小狼毫0.15.0ˋ亦32位者也。

欲使c\# aot 編譯得32位之dll、把`win-64`改潙`win-x86`



= c\#插件不給報錯ʹ訊

[2024-11-14T17:02:41.999+08:00]

==
```bash
dotnet new sln -n cli-tools
dotnet sln add aot/aot.csproj
```



= efcore 遷移
[2024-12-06T21:09:22.901+08:00_W49-5]
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update

創建遷移
dotnet ef migrations add _20241104214647_add_WordFreq

移除未使用的遷移
dotnet ef migrations remove

回滾到指定遷移
dotnet ef database update InitialCreate
```

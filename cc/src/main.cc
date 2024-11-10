#include <iostream>
#include <windows.h>
#include <string>

typedef int (__cdecl *AddFunc)(int, int);

int main() {
	std::string dllPath = "e:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/publish/aot.dll";

	std::cout << dllPath << std::endl;
	std::cout << "Loading dll..." << std::endl;

	HINSTANCE hinstLib = LoadLibrary(dllPath.c_str());
	if (hinstLib == NULL) {
		std::cerr << "LoadLibrary failed." << std::endl;
		return 1;
	}

	typedef AddFunc AddFunc;
	AddFunc add = (AddFunc)GetProcAddress(hinstLib, "tsins_add__stdcall"); // cdecl與stdcall皆可
	if (add == NULL) {
		std::cerr << "GetProcAddress failed: "<< GetLastError() << std::endl;
		FreeLibrary(hinstLib);
		return 1;
	}

	auto result = add(1, 2);
	std::cout << "1 + 2 = " << result << std::endl;

	FreeLibrary(hinstLib);
	return 0;
}
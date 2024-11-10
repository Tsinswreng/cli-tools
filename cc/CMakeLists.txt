# cd build && cmake -G Ninja
# ninja
	cmake_minimum_required(VERSION 3.5)
	set(CMAKE_VERBOSE_MAKEFILE OFF)
	
	# 设置 C 编译器和 C++ 编译器
	set(CMAKE_CXX_STANDARD 20)
	set(CMAKE_C_COMPILER gcc)
	set(CMAKE_CXX_COMPILER g++)

	
	project(ngaq)
	
	# 引入 vcpkg 库
	# 有效>
	set(nlohmann_json_DIR "${CMAKE_SOURCE_DIR}/vcpkg_installed/x64-windows/share/nlohmann_json")
	# 不效>
	set(CMAKE_PREFIX_PATH "${CMAKE_SOURCE_DIR}/vcpkg_installed/x64-windows/share/nlohmann_json" ${CMAKE_PREFIX_PATH})
	string(REPLACE ";" "\n" cmake_prefix_path_str "${CMAKE_PREFIX_PATH}")
	
	#find_package(nlohmann_json REQUIRED)


	
	# 從src根目錄開始找
	include_directories(${CMAKE_SOURCE_DIR}/src)
	file(GLOB_RECURSE ngaq_SRC
		"src/**.h"
		"src/**.cc"
		"src/**.hpp"
		"src/**.cpp"
		"src/**.c"
	)
	# 将文件列表转换为一个以分号分隔的字符串
	string(REPLACE ";" "\n" ngaq_SRC_STRING "${ngaq_SRC}")
	
	# 打印文件列表
	#message("Found source files:\n${ngaq_SRC_STRING}")
	
	add_executable(ngaq ${ngaq_SRC})
	#add_library(_ STATIC ${ngaq_SRC})
	
	
	#set_target_properties(_ PROPERTIES COMPILE_FLAGS "${EM_CFLAGS}")
	
	
	#target_link_libraries(ngaq nlohmann_json::nlohmann_json)


	# target_link_libraries(ngaq aot)
	# target_link_directories(ngaq PUBLIC "E:/_code/rime-tools/aot/bin/Release/net9.0/win-x64")
	# add_library(aot SHARED IMPORTED)

	# set_target_properties(
	# 	aot
	# 	PROPERTIES
	# 	IMPORTED_LOCATION
	# 	"E:/_code/rime-tools/aot/bin/Release/net9.0/win-x64/aot.dll"
	# )
	#cmake_policy(SET CMP0111 NEW)
	
	#{
	#https://github.com/clangd/clangd/issues/1621
	set(CMAKE_EXPORT_COMPILE_COMMANDS ON)
	
	# 静态链接標準庫 (不能用c++23、否則鏈接失敗)
	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -static-libgcc -static-libstdc++")
	#target_link_libraries(ngaq -static-libgcc -static-libstdc++)
	#target_link_libraries(ngaq -static-libgcc -static-libstdc++)
	
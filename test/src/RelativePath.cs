using System;
using System.IO;
namespace test;
public class RelativePath{
	public static str Main(){
		// 定义一个相对路径
		string relativePath = "."; // 假设文件在当前工作目录下
		// 将相对路径转换为绝对路径
		string absolutePath = Path.GetFullPath(relativePath);
		// 输出绝对路径
		return absolutePath;
	}
}

/* 
我的命令行的工作目錄是/e/_code/rime-tools
我在測試用例中獲取"."的絕對路徑並輸出
我使用//dotnet test --filter "FullyQualifiedName~test.UnitTest1.Test1" --logger "console;verbosity=detailed"
命令來運行測試用例
但是輸出的是
E:\_code\rime-tools\test\bin\Debug\net8.0 
爲甚麼
 */

/* 
		//await AsyncReadLine.Main();
		// var ans = RelativePath.Main();
		// System.Console.WriteLine(ans);
		// var basePath = AppContext.BaseDirectory;
		// System.Console.WriteLine(basePath);
 		// var dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
		// System.Console.WriteLine(dir);
 */
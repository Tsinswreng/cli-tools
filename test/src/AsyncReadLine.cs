namespace test;


public class AsyncReadLine{
	static string filePath = "../../../../.gitignore"; // 替换为你的文件路径
	static StreamReader reader = new StreamReader(filePath);
	public static async Task<string?> ReadLineAsync(){
		return await reader.ReadLineAsync(); // 每次调用读取一行
	}

	public static async Task Main(){
		/* 
		“IAsyncEnumerable<string?>”未包含“GetAwaiter”的定义，并且找不到可接受第一个“IAsyncEnumerable<string?>”类型参数的可访问扩展方法“GetAwaiter”(是否缺少 using 指令或程序集引用?)CS1061
		 */
		string? line;
		for (var i = 0;(line = await ReadLineAsync()) != null; i++){
			System.Console.WriteLine(i);
			Console.WriteLine(line);
		}
		
	}
}

		// var reader = xxx
		// for(;reader.hasNext();){
		// 	var line = await reader.readLineAsync();
		// }
		// using (var reader = new StreamReader(filePath)){
		// 	yield return await reader.ReadLineAsync();
		// 	// string line;
		// 	// while ((line = await reader.ReadLineAsync()) != null){
		// 	// 	yield return line;
		// 	// }
		// }
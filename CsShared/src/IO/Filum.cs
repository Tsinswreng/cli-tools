namespace Shr.IO.Filum;

public class Filum{
	public static zero Ensure(string filePath){
		// 获取文件的目录路径
		var dirPath = Path.GetDirectoryName(filePath);

		// 如果目录不存在,则递归创建目录
		if (dirPath == null || !Directory.Exists(dirPath)){
			Directory.CreateDirectory(dirPath!);
		}

		// 如果文件不存在,则创建文件
		if (!File.Exists(filePath)){
			File.Create(filePath).Dispose();
		}
		return 0;
	}
}
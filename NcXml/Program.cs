/*

 */

using System;
using System.IO;
using NcXml;


static void ensureFile(string filePath){
	// 获取文件的目录路径
	string directoryPath = Path.GetDirectoryName(filePath);

	// 如果目录不存在,则递归创建目录
	if (!Directory.Exists(directoryPath)){
		Directory.CreateDirectory(directoryPath);
	}

	// 如果文件不存在,则创建文件
	if (!File.Exists(filePath)){
		File.Create(filePath).Dispose();
	}
}

static zero main(string[] args){
	var affix = ".nc.xml";
	var dirPath = args[0];
	var filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);


	var parser = new ParseFile();
	var nsignXmlFiles = filePaths.Where(e=>e.EndsWith(affix)).ToList();
	foreach(var filePath in nsignXmlFiles){
		ensureFile(filePath);
		parser.parse(filePath);
	}
	return 0;
}

using (FileSystemWatcher watcher = new FileSystemWatcher()){
	// 設置要監視的目錄和文件類型
	var path = "./cxml.nc.xml";
	ensureFile(path);
	watcher.Path = Path.GetDirectoryName(path);
	watcher.Filter = Path.GetFileName(path);

	// 設置監視的事件
	watcher.Changed += (a,b)=>{
		//System.Console.WriteLine("File changed: " + b.FullPath);
		try{
			System.Threading.Thread.Sleep(100);
			var txt = File.ReadAllText(b.FullPath);
			System.Console.WriteLine(txt);
		}
		catch (System.Exception e){
			System.Console.WriteLine(e);
		}
	};
	watcher.EnableRaisingEvents = true;

	// 防止程序立即退出
	Console.WriteLine("Press 'q' to quit the sample.");
	while (Console.Read() != 'q') ;
}
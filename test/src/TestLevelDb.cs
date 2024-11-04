//LevelDB.Standard
using LevelDB;
using System;
using System.IO;
namespace test;

public class TestLevelDb{
	public static void _Main(){
		var path = "d:/Program Files/Rime/User_Data/_userdb/_commitHistory/20240528183601commitHistory.ldb";
		string dbPath = Path.Combine(Path.GetTempPath(), path);

		// 打开数据库，创建数据库如果不存在
		var options = new Options { CreateIfMissing = true };
		using (var db = new DB(options, dbPath)){
			// 写入数据
			// db.Put("key1", "value1");
			// db.Put("key2", "value2");

			// 读取数据
			// string value1 = db.Get("key1");
			// Console.WriteLine($"Value for key1: {value1}"); // 输出 Value for key1: value1

			// string value2 = db.Get("key3"); // 读取不存在的键
			// Console.WriteLine($"Value for key3: {value2}"); // 输出 Value for key3: 

			// 删除数据
			// db.Delete("key1");
			using (var iter = db.CreateIterator()){
				for(var i = 0; iter.IsValid(); i ++){
					G.log(i);
					var key = iter.Key();
					var value = iter.Value();
					Console.WriteLine($"Key: {key}, Value: {value}");
					iter.Next();
				}
			}
		}

		// 验证数据是否已删除 (可选)
		// using (var db = new DB(options, dbPath)){
		// 	string valueAfterDelete = db.Get("key1");
		// 	Console.WriteLine($"Value for key1 after delete: {valueAfterDelete}"); // 输出 Value for key1 after delete: 
		// }
		// Console.ReadKey();
	}
}
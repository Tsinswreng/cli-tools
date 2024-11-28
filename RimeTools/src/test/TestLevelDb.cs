//LevelDB.Standard
using LevelDB;
using System;
using System.IO;
using System.Text;
namespace test;

public class TestLevelDb{
	public static void _Main(){
		var path = "d:/Program Files/Rime/User_Data/_userdb/_commitHistory/20240528183601commitHistory.ldb";
		//string dbPath = Path.Combine(Path.GetTempPath(), path);
		string dbPath = path;
		G.log(dbPath);
		// 打开数据库，创建数据库如果不存在
		var options = new Options { CreateIfMissing = true };
		using (var db = new DB(options, dbPath)){
			using (var iter = db.CreateIterator()){
				for (iter.SeekToFirst(); iter.IsValid(); iter.Next()){
					string key = Encoding.UTF8.GetString(iter.Key()??[]);
					string value = Encoding.UTF8.GetString(iter.Value()??[]);
					Console.WriteLine($"Key: {key}, Value: {value}");
				}
			}
		}




	}
}
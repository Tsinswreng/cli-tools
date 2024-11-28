using LevelDB;
using System;
using System.IO;
using System.Text;

namespace db;

public class LevelDbReader: IDisposable, I_LevelDbReader {
	public LevelDbReader(str path) {
		_path = path;
		this._db = new DB(options, _path);
	}

	~LevelDbReader(){
		Dispose();
	}
	public void Dispose() {
		this._db.Dispose();
	}

	protected str _path;
	protected DB _db;
	
	public Options options{get;set;} = new Options { CreateIfMissing = true };

	public (str,str) getNext(){
		using (var iter = _db.CreateIterator()){
			for (iter.SeekToFirst(); iter.IsValid(); iter.Next()){
				string key = Encoding.UTF8.GetString(iter.Key()??[]);
				string value = Encoding.UTF8.GetString(iter.Value()??[]);
				Console.WriteLine($"Key: {key}, Value: {value}");
			}
		}
	}

	public bool hasNext(){

	}
}

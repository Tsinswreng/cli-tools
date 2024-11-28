using LevelDB;
using System;
using System.IO;
using System.Text;

namespace db;

public class LevelDbReader: IDisposable, I_LevelDbProcessor {
	public LevelDbReader(str path, Func<(str,str), code> process) {
		_path = path;
		this._db = new DB(options, _path);
		this.process = process;
	}

	~LevelDbReader(){
		Dispose();
	}
	public void Dispose() {
		this._db.Dispose();
	}

	protected str _path;
	protected DB _db;

	public Func<(str,str), code> process{get;set;}
	
	public Options options{get;set;} = new Options { CreateIfMissing = true };

	public code start(){
		using (var iter = _db.CreateIterator()){
			for (iter.SeekToFirst(); iter.IsValid(); iter.Next()){
				string key = Encoding.UTF8.GetString(iter.Key()??[]);
				string value = Encoding.UTF8.GetString(iter.Value()??[]);
				//Console.WriteLine($"Key: {key}, Value: {value}");
				var ans = process((key, value));
				if (ans!= 0) {return ans;}
			}
		}
		return 0;
	}


}

using System.Text;
using System;
using System.IO;
using model;
using model.consts;
using Microsoft.EntityFrameworkCore;
using db;
namespace ctrler;


/* 
var adder = new ctrler.AddWordFreq(
	"c:/Users/lenovo/AppData/Roaming/plum/package/rime/essay/essay.txt"
	, Encoding.UTF8
);

await adder.Add();
G.log("done");

 */


// temp
class AddWordFreq{
	public AddWordFreq(str path, Encoding encoding){
		this.path = path;
		this.encoding = encoding;
	}

	public str path{get;set;}
	public Encoding encoding{get;set;}


	protected str _readFile(){
		return File.ReadAllText(path, encoding);
	}

	protected WordFreq _lineToWordFreq(str left, str right){
		var ans = new WordFreq();
		ans.bl = "essay";
		ans.kStr = left;
		ans.kType = KVType.STR.ToString();
		ans.vType = KVType.I64.ToString();
		ans.vI64 = Int64.Parse(right);
		
		return ans;
	}

	protected IList<WordFreq> _parse(str src){
		var lines = src.Split("\n");
		var ans = new List<WordFreq>();
		for(var i=0;i<lines.Length;i++){
			var line = lines[i].Trim();
			if(line.Length==0){
				continue;
			}
			var parts = line.Split('\t');
			var left = parts[0];
			var right = parts[1];
			var ua = _lineToWordFreq(left, right);
			ans.Add(ua);
		}
		return ans;
	}

	protected code _addToDb(IList<WordFreq> entites){
		var dbCtx = new RimeDbContext();
		dbCtx.WordFreq.AddRange(entites);
		dbCtx.SaveChanges();
		return 0;
	}

	public async Task<code> Add(){
		var src = _readFile();
		var entites = _parse(src);
		_addToDb(entites);
		return 0;
	}
}

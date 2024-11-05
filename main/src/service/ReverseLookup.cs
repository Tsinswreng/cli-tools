using db;
using model;
using model.consts;

namespace service;

public class ReverseLookup: I_seekCode{

	protected RimeDbContext _dbContext = new RimeDbContext();

	public IList<I_KV> seekCode_KV(str dzvs){
		var ctx = _dbContext;
// 		var sql = 
// $@"select * from {nameof(KV)} where 
// 	{nameof(KV.kStr)} = @dzvs
// ";
		return (IList<I_KV>)ctx.KV
			.Where(e=>e.kStr==dzvs && e.vDesc == VDesc.text.ToString())
			.ToList()
		;
	}

	/// <summary>
	/// 字-碼 ˉ對ˇ 轉 List<碼> ʰ
	/// </summary>
	/// <param name="kvs"></param>
	/// <returns></returns>
	public IList<str> kvsToStrs(IList<I_KV> kvs){
		var ans = new List<str>();
		foreach(var kv in kvs){
			if(
				kv.kType == KVType.STR.ToString()
				&& kv.vDesc == VDesc.text.ToString()
			){
				ans.Add(kv.vStr??"");
			}
		}
		return ans;
	}

	/// @IF_FN
	public IList<str> seekCode(str dzvs){
		var kvs = seekCode_KV(dzvs);
		return kvsToStrs(kvs);
	}

	public IList< IList<str> > seekCode(IList<str> tshvq){
		//TODO
		return [];
	}
}
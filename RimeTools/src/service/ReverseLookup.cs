using db;
using model;
using model.consts;

namespace service;


/// <summary>
/// temp
/// </summary>
public class ReverseLookup: I_seekCode{

	public ReverseLookup(str dictName){
		this.dictName = dictName;
	}

	protected RimeDbContext _dbContext = new RimeDbContext();

	public str dictName{get;set;}

	public IList<I_KV> seekCode_KV(str dzvs){
		var bl = BlPrefix.parse(BlPrefix.dictYaml, dictName);
		var ctx = _dbContext;
		var ans = ctx.KV
			.Where(
				e=>e.kStr==dzvs 
				&& e.vDesc == VDesc.text.ToString()
				&& e.bl == bl
			)
			.Cast<I_KV>()
			.ToList()
		;
		// for(var i = 0; i < ans.Count; i++){
		// 	var e = ans[i];
		// 	// if(e?.vStr?.Length == 5){
		// 	// 	e.vStr = e.vStr.Substring(0,3); // dks_v取前三字
		// 	// }
		// }
		return ans;
	}

	/// <summary>
	/// 字-碼 ˉ對ˇ 轉 List<碼> ʰ
	/// </summary>
	/// <param name="kvs"></param>
	/// <returns></returns>
	protected IList<str> kvsToStrs(IList<I_KV> kvs){
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
	/// <summary>
	/// 由單字尋碼 fn("車") -> ["che1","ju1"] ; fn("輛") -> ["liang4"]
	/// </summary>
	/// <param name="dzvs"></param>
	/// <returns></returns>
	public IList<str> seekCode(str dzvs){
		var kvs = seekCode_KV(dzvs);
		return kvsToStrs(kvs);
	}

	/// @IF_FN
	/// <summary>
	/// 由多字尋碼 fn(["車", "輛"]) -> 
	/// [ ["che1","liang4"], ["ju1", "liang4"] ]
	/// </summary>
	/// <param name="tshvq"></param>
	/// <returns></returns>
	public IList< IList<str> > seekCode(IList<str> tshvq){
		var list2d = tshvq.Select(e=>seekCode(e)).ToList();
		var ans = tools.Tools.cartesianProduct(list2d);
		return ans;
	}
}


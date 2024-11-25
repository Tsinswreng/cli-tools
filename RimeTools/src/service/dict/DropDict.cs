using db;
using Microsoft.EntityFrameworkCore;
using model;
using model.consts;
using service.dict;

namespace service;
//, IF.I_Transaction
public class DictDropper : IDisposable, I_Tx_DropDict{

	public DictDropper(){}
	~DictDropper(){
		Dispose();
	}
	public void Dispose(){
		dbCtx.Dispose();
	}
	
	public RimeDbContext dbCtx = new();

	public str sql = 
@$"DELETE FROM {nameof(KV)}
WHERE {nameof(KV.bl)} = @{nameof(KV.bl)}
";

	public async Task<code> Begin(){
		return 0;
	}

	public async Task<code> Commit(){
		return 0;
	}

	public async Task<code> DropDict(str name){
		var bl = parseBl(name);
		
		return 0;
	}

	protected str parseBl(str name){
		return BlPrefix.parse(BlPrefix.dictYaml, name);
	}

	
}

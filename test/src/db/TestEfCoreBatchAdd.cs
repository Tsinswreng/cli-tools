using model;
using db;
using System.Diagnostics;
namespace test.db;

public class TestEfCoreBatchAdd{

	public static KV[] geneKVs(int count){
		KV[] ans = new KV[count];
		for(int i=0; i<count; i++){
			KV kv = new KV();
			kv.kStr = "key"+i;
			kv.kI64 = i;
			kv.vStr = "value"+i;
			kv.bl = "test";
			ans[i] = kv;
		}
		return ans;
	}

	public static async Task AddRange(){
		var sw = new Stopwatch();
		
		var dbCtx = new RimeDbContext();
		var trans = await dbCtx.BeginTrans();
		sw.Start();var kvs = geneKVs(9999);
		await dbCtx.KVEntities.AddRangeAsync(kvs);
		dbCtx.SaveChanges();
		sw.Stop();
		await trans.CommitAsync();
		dbCtx.Dispose();
		Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);
	}
}
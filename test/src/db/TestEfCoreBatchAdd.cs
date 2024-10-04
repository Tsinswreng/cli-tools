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
			kv.kType = model.consts.KVType.STR.ToString();
			kv.vStr = "value"+i;
			kv.bl = "test";
			ans[i] = kv;
		}
		return ans;
	}

//3.6790 秒 9999個
	public static async Task AddRange(){
		var sw = new Stopwatch();
		
		var dbCtx = new RimeDbContext();
		var trans = await dbCtx.BeginTrans();
		sw.Start();
		var kvs = geneKVs(9999);
		await dbCtx.KVEntities.AddRangeAsync(kvs);
		dbCtx.SaveChanges();
		sw.Stop();
		await trans.CommitAsync();
		dbCtx.Dispose();
		Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);
	}

//5.6688 秒
	public static async Task AddWithLastId1(){
		;var sw = new Stopwatch();
		;var dbCtx = new RimeDbContext();
		;var trans = await dbCtx.BeginTrans();
		;sw.Start();
		;var kvs = geneKVs(9999);
		for(var i = 0; i<kvs.Length; i++){
			;var cur = kvs[i];
			;await dbCtx.KVEntities.AddRangeAsync(cur);
			;G.log(cur.id); //取不到新分配之自增id
		}
		;dbCtx.SaveChanges();
		;trans.Commit();
		;sw.Stop();
		;dbCtx.Dispose();
		;Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);
	}

	//太慢 未候盡、一秒不到1000個
	public static async Task AddWithLastId2(){
		;var sw = new Stopwatch();
		;var dbCtx = new RimeDbContext();
		;var trans = await dbCtx.BeginTrans();
		;sw.Start();
		;var kvs = geneKVs(9999);
		for(var i = 0; i<kvs.Length; i++){
			;var cur = kvs[i];
			;await dbCtx.KVEntities.AddRangeAsync(cur);
			;await dbCtx.SaveChangesAsync();
			;G.log(cur.id); //能取到新分配之自增id
		}
		;trans.Commit();
		;sw.Stop();
		;dbCtx.Dispose();
		;Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);
	}

	// 改用AddAsync亦無效
	public static async Task AddWithLastId3(){
		;var sw = new Stopwatch();
		;var dbCtx = new RimeDbContext();
		;var trans = await dbCtx.BeginTrans();
		;var kvs = geneKVs(9999);
		;sw.Start();
		for(var i = 0; i<kvs.Length; i++){
			;var cur = kvs[i];
			;await dbCtx.KVEntities.AddAsync(cur); //
			;await dbCtx.SaveChangesAsync();
			;G.log(cur.id); //能取到新分配之自增id
		}
		;trans.Commit();
		;sw.Stop();
		;dbCtx.Dispose();
		;Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);
	}
}

/* 

last_insert_rowid

sqlite 在事務中批量插入時、如何每次插入一個對象後就立即獲取lastId？ 能通過sql實現嗎?

c# ecfore 在事務中批量插入時、如何每次插入一個對象後就立即獲取lastId？


在node的sqlite3庫中、我開啓一個事務後、多次調用statement.run()方法插入對象
每次調用run方法之後、都能在回調函數中獲取lastId與affectedRows、(此時並未提交事務)
假設我有兩種實體A和B、B的kI64字段指向A的主鍵、A的主鍵又是自增id
A和B存在同一張表中。A和B的實體結構都相同 如下:
{
	id: int
	,kI64: int
}
在node的sqlite3庫中 當我開啓事務 批量插入A和B時、我先插入A、再獲取A的lastId
再將A的lastId 填入B的kI64欄位、並插入B
最後再提交事務。

c#的efcore怎麼實現

這樣效率太低了、1分鍾都插入不完10000條數據、跟沒開事務沒區別。我用node sqlite3庫 開事務再在回調裏取lastId 、同樣的數據量 幾秒鍾就插入完了。
efcore 獲取插入對象成 他給我生成的sql、我只要sql、不要執行操作。

node 的sqlite3庫中 prepare方法可以提前編譯sql、然後再執行。
當我需要用同樣的sql來批量插入多條數據時、我可以先用prepare方法編譯sql、然後再在循環中用statement.run方法執行。
c# efcore有類似的機制 防止多次編譯相同的sql嗎?

using Microsoft.EntityFrameworkCore;
using System.Transactions;

// ... your DbContext and entity classes ...

public async Task InsertEntitiesAsync(List<EntityA> entitiesA, List<EntityB> entitiesB)
{
    using (var transaction = new TransactionScopeAsync())
    {
        try
        {
            // Insert entities A
            await _context.EntitiesA.AddRangeAsync(entitiesA);
            await _context.SaveChangesAsync(); // Save changes to get the generated IDs

            // Update foreign keys in entities B and insert
            foreach (var entityB in entitiesB)
            {
                // Find the corresponding EntityA based on your logic (e.g., using a property)
                var relatedEntityA = _context.EntitiesA.FirstOrDefault(a => a.SomeProperty == entityB.SomeProperty);

                if (relatedEntityA != null)
                {
                    entityB.EntityAId = relatedEntityA.Id; // Set the foreign key
                }
                else
                {
                    // Handle the case where the related EntityA is not found.  
                    // You might throw an exception or skip this EntityB.
                    throw new Exception($"EntityA not found for EntityB with SomeProperty: {entityB.SomeProperty}");
                }
            }
            await _context.EntitiesB.AddRangeAsync(entitiesB);
            await _context.SaveChangesAsync();

            transaction.Complete(); // Commit the transaction
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., rollback transaction)
            Console.WriteLine($"Transaction failed: {ex.Message}");
            // Consider more robust error handling and logging here.
        }
    }
}


// Example usage:
List<EntityA> entitiesA = new List<EntityA>();
// ... populate entitiesA ...

List<EntityB> entitiesB = new List<EntityB>();
// ... populate entitiesB, ensuring you have the necessary linking property ...

await InsertEntitiesAsync(entitiesA, entitiesB);

 */
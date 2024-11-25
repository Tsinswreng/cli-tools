using db;
using Microsoft.EntityFrameworkCore;
using model;
using service;
using service.parser;
using service.parser.dictYamlParser;

namespace ctrler;

//TODO 製 專加KV之adder
public class DictLineKVsAdder : I_AdderAsync<DictLineKVs>{
	public I_AdderAsync<KV> kvAdder {get;set;} = new KVAdder();
	//public Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? trans{get;set;}

	public DictLineKVsAdder(){

	}

	public async Task Begin(){
		await kvAdder.Begin();
	}

	public async Task Commit(){
		await kvAdder.Commit();
	}

	public async Task<I_lastId?> Add(DictLineKVs kvs){
		var text__code = kvs.text__code;

		var fKey__weight = kvs.fKey__weight;
		var ua = await kvAdder.Add(text__code);
		//var lastId = text__code.id;
		if(ua == null){
			return null;
		}
		var lastId = ua.lastId;
		if(fKey__weight == null){
			return ua;
		}
		fKey__weight.kI64 = lastId;
		return await kvAdder.Add(fKey__weight);
		// await dbCtx.KVEntities.AddAsync(fKey__weight);
		// await dbCtx.SaveChangesAsync();
	}

	~DictLineKVsAdder(){
		
	}
}

public class AddDictInDb{
	protected DictMetadata? metadata {get;set;}
	protected I_lineStrToKVs? lineStrToKVs;

	protected DictLineKVsAdder dictLineKVsAdder {get;set;} = new DictLineKVsAdder();

	protected i32 _initDeps(DictMetadata metadata){
		this.metadata = metadata;
		lineStrToKVs = new DictLineParser(metadata);
		return 0;
	}

	public DictLineKVs lineStrToModel(str line){
		return G.nn(lineStrToKVs).lineStrToKVs(line);
	}

	public async Task AddLineStr(str line){
		var kvs = lineStrToKVs!.lineStrToKVs(line);
		await dictLineKVsAdder.Add(kvs);
	}

	public async Task AddFromPath(string dictPath){
		I_ReadLine lineReader = new LineReader(dictPath);
		var tasks = new List<Task>();
		var dictYamlParser = new DictYamlParser(
			lineReader
			,(state) => {
				try{
					var line = state.curLine;
					if(line == null || line.Trim() == ""){
						return 0;
					}
					line = DictYamlParser.rmLineComment(line);
					var t = AddLineStr(line);
					// .ContinueWith((t)=>{
					// 	if (t.IsFaulted) {
					// 		var exception = t.Exception;
					// 		if (exception != null) {
					// 			// foreach (var innerException in exception.InnerExceptions) {
					// 			// 	Console.Error.WriteLine($"Exception: {innerException.GetType().Name}: {innerException.Message}");
					// 			// 	Console.Error.WriteLine($"Stack Trace: {innerException.StackTrace}");
					// 			// }
					// 			Console.Error.WriteLine($"Line Number: {state.lineNum}");
					// 		}
					// 	}
					// });
					tasks.Add(t);
				}catch (Exception ex){
					Console.Error.WriteLine(ex);
					Console.Error.WriteLine(state.lineNum);
				}
				return 0;
			}
		);

		dictYamlParser.onMetadata = (meta) => {
			_initDeps(meta);
			return 0;
		};
		await dictLineKVsAdder.Begin();
		await dictYamlParser.Parse();
		await Task.WhenAll(tasks);
		await dictLineKVsAdder.Commit();
	}

}


/* 
在node的sqlite3庫中、我開啓一個事務後、多次調用statement.run()方法插入對象
每次調用run方法之後、都能在回調函數中獲取lastId、(此時並未提交事務)
c#的efcore怎麼做?
using (var context = new YourDbContext())
{
    using (var transaction = await context.Database.BeginTransactionAsync())
    {
        try
        {
            // 假设您有一个名为 YourEntity 的实体
            for (int i = 0; i < 5; i++)
            {
                var entity = new YourEntity
                {
                    // 设置实体的属性
                };

                // 添加实体到上下文
                await context.YourEntities.AddAsync(entity);
                
                // 保存更改以获取 lastId
                await context.SaveChangesAsync();

                // 获取插入的实体的 ID
                var lastId = entity.Id; // 假设 Id 是主键属性
                Console.WriteLine($"Inserted entity with ID: {lastId}");
            }

            // 提交事务
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            // 处理异常并回滚事务
            await transaction.RollbackAsync();
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
 */
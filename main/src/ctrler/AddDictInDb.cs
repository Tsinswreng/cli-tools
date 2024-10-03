using db;
using model;
using service;
using service.parser;
using service.parser.dictYamlParser;

namespace ctrler;


public class DictLineKVsAdder{
	
	public RimeDbContext dbCtx = new RimeDbContext();
	public Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? trans;

	DictLineKVsAdder(){

	}

	public async Task Begin(){
		trans = await dbCtx.BeginTrans();
	}

	public async Task Commit(){
		if(trans != null){
			await trans.CommitAsync();
			trans.Dispose();
		}
	}

	public async Task Add(DictLineKVs kvs){
		var text__code = kvs.text__code;
		var fKey__weight = kvs.fKey__weight;
		await dbCtx.KVEntities.AddAsync(text__code);
		await dbCtx.SaveChangesAsync();
		var lastId = text__code.id;
		if(fKey__weight == null){
			return;
		}
		fKey__weight.kI64 = lastId;
		await dbCtx.KVEntities.AddAsync(fKey__weight);
		await dbCtx.SaveChangesAsync();
	}

	~DictLineKVsAdder(){
		dbCtx.Dispose();
	}
}

public class AddDictInDb{

	protected DictMetadata? metadata {get;set;}
	protected I_lineStrToKVs? lineStrToKVs;

	protected i32 _initDeps(DictMetadata metadata){
		this.metadata = metadata;
		lineStrToKVs = new DictLineParser(metadata);
		return 0;
	}

	public DictLineKVs lineStrToModel(str line){
		return G.nn(lineStrToKVs).lineStrToKVs(line);
	}

	

	public async Task AddKVs(DictLineKVs kvs){
		
	}
	
	public async Task Run(string dictPath){
		I_LineReader lineReader = new LineReader(dictPath);
		var dictYamlParser = new DictYamlParser(
			lineReader
			, (state) => {
				//TODO add in db
				if(metadata == null){
					_initDeps(G.nn(state.metadata));
				}
				
				return 0;
			}
		);

		

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
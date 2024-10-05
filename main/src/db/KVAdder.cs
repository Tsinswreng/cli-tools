using model;
using db;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite; // 对于 SQLite
using System.Data;


namespace db;

public class KVAdder : I_Adder<KV>, IDisposable{

	public str sql_add = 
@$"INSERT INTO {nameof(KV)} (
	 {nameof(KV.bl)}
	,{nameof(KV.kType)}
	,{nameof(KV.kStr)}
	,{nameof(KV.kI64)}
	,{nameof(KV.kDesc)}
	,{nameof(KV.vType)}
	,{nameof(KV.vStr)}
	,{nameof(KV.vI64)}
	,{nameof(KV.vF64)}
	,{nameof(KV.vDesc)}
)VALUES (
	 @{nameof(KV.bl)}
	,@{nameof(KV.kType)}
	,@{nameof(KV.kStr)}
	,@{nameof(KV.kI64)}
	,@{nameof(KV.kDesc)}
	,@{nameof(KV.vType)}
	,@{nameof(KV.vStr)}
	,@{nameof(KV.vI64)}
	,@{nameof(KV.vF64)}
	,@{nameof(KV.vDesc)}
)";

	public str sql_lastId = "SELECT last_insert_rowid()";

	public KVAdder(){}

	~KVAdder(){
		Dispose();
	}

	public void Dispose(){
		dbCtx.Dispose();
		conn.Dispose();
		cmd_add.Dispose();
		cmd_lastId.Dispose();
		trans.Dispose();
	}

	public System.Data.Common.DbCommand cmd_add{get;set;}
	public System.Data.Common.DbCommand cmd_lastId{get;set;}

	public IDbContextTransaction trans{get; set;}

	public RimeDbContext dbCtx{get; set;} = new();
	public System.Data.Common.DbConnection conn{get; set;}

	


	public async Task Begin(){
		conn = dbCtx.Database.GetDbConnection();
		await conn.OpenAsync();
		cmd_add = conn.CreateCommand();
		cmd_add.CommandText = sql_add;
		cmd_add.CommandType = System.Data.CommandType.Text;

		cmd_lastId = conn.CreateCommand();
		cmd_lastId.CommandText = sql_lastId;
		cmd_lastId.CommandType = System.Data.CommandType.Text;

		trans = await dbCtx.BeginTrans();

		cmd_add.Transaction = trans.GetDbTransaction();
		cmd_lastId.Transaction = trans.GetDbTransaction();

		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.bl)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.kType)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.kStr)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.kI64)}", DbType.Int64));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.kDesc)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.vType)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.vStr)}", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.vI64)}", DbType.Int64));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.vF64)}", DbType.Single));
		cmd_add.Parameters.Add(new SqliteParameter($"{nameof(KV.vDesc)}", DbType.String));

	}

	public async Task<I_lastId> Add(KV e){

		cmd_add.Parameters[$"{nameof(KV.bl)}"].Value = e.bl;
		cmd_add.Parameters[$"{nameof(KV.kType)}"].Value = e.kType;
		cmd_add.Parameters[$"{nameof(KV.kStr)}"].Value = e.kStr;
		cmd_add.Parameters[$"{nameof(KV.kI64)}"].Value = e.kI64;
		cmd_add.Parameters[$"{nameof(KV.kDesc)}"].Value = e.kDesc;
		cmd_add.Parameters[$"{nameof(KV.vType)}"].Value = e.vType;
		cmd_add.Parameters[$"{nameof(KV.vStr)}"].Value = e.vStr;
		cmd_add.Parameters[$"{nameof(KV.vI64)}"].Value = e.vI64;
		cmd_add.Parameters[$"{nameof(KV.vF64)}"].Value = e.vF64;
		cmd_add.Parameters[$"{nameof(KV.vDesc)}"].Value = e.vDesc;

		await cmd_add.ExecuteNonQueryAsync(); // 执行命令
		var result = await cmd_lastId.ExecuteScalarAsync(); // 獲取lastId

		var ans = new RunResult{lastId = (i64)result};
		return ans;
		// var t = Task.FromResult(ans);
		// return (I_lastId)t;
	}

	public async Task Commit(){
		trans.Commit();
	}
}


/* 

public static async Task AddWithRawSql(){
		RimeDbContext dbCtx = new();
		var conn = dbCtx.Database.GetDbConnection();
		//var insertSql = "INSERT INTO KV (kStr, kType, vStr, bl) VALUES (?, ?, ?, ?)";
		var insertSql = "INSERT INTO KV (kStr, kType, vStr, bl) VALUES (@kStr, @kType, @vStr, @bl)";
		var sql_lastId = "SELECT last_insert_rowid()";
		await conn.OpenAsync();

		var cmd_add = conn.CreateCommand();
		cmd_add.CommandText = insertSql;
		cmd_add.CommandType = System.Data.CommandType.Text;

		var cmd_lastId = conn.CreateCommand();
		cmd_lastId.CommandText = sql_lastId;
		cmd_lastId.CommandType = System.Data.CommandType.Text;

		// 执行命令
		//await cmd_add.ExecuteNonQueryAsync();
		//var result = await cmd.ExecuteScalarAsync();
		;var sw = new Stopwatch();
		;var trans = await dbCtx.BeginTrans();
		;var kvs = geneKVs(9999);

		cmd_add.Transaction = trans.GetDbTransaction();
		cmd_lastId.Transaction = trans.GetDbTransaction();
		
		cmd_add.Parameters.Add(new SqliteParameter("@kStr", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter("@kType", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter("@vStr", DbType.String));
		cmd_add.Parameters.Add(new SqliteParameter("@bl", DbType.String));

		;sw.Start();
		for(var i = 0; i<kvs.Length; i++){
			;var cur = kvs[i];
			cmd_add.Parameters["@kStr"].Value = cur.kStr;
			cmd_add.Parameters["@kType"].Value = cur.kType;
			cmd_add.Parameters["@vStr"].Value = cur.vStr;
			cmd_add.Parameters["@bl"].Value = cur.bl;
			await cmd_add.ExecuteNonQueryAsync(); // 执行命令
			var result = await cmd_lastId.ExecuteScalarAsync(); // 獲取lastId
			G.log(result);//t
		}
		;trans.Commit();
		;sw.Stop();
		;dbCtx.Dispose();
		;Console.WriteLine("Add KV entities in {0} ms", sw.ElapsedMilliseconds);


 */
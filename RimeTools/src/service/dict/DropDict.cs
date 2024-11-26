using System.Data;
using db;
using IF;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
		_dbCtx.Dispose();
	}
	
	public str sql {get;set;}= 
@$"DELETE FROM {nameof(KV)}
WHERE {nameof(KV.bl)} = @{nameof(KV.bl)}
";
	
	protected System.Data.Common.DbCommand _cmd;
	protected RimeDbContext _dbCtx = new();
	protected System.Data.Common.DbConnection _conn{get; set;}
	protected IDbContextTransaction _trans{get; set;}

	public str dictName{get;set;}
	
	/// <summary>
	/// null convert to DBNull.Value
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	protected unknown nc<T>(T? v){
		if(v == null){
			return DBNull.Value;
		}
		return v;
	}

	public async Task<code> Begin(){
		_conn = _dbCtx.Database.GetDbConnection();
		await _conn.OpenAsync();
		_cmd = _conn.CreateCommand();
		_cmd.CommandText = sql;
		_cmd.CommandType = System.Data.CommandType.Text;
		_trans = await _dbCtx.BeginTrans();
		_cmd.Parameters.Add(new SqliteParameter($"@{nameof(KV.bl)}", DbType.String));
		_cmd.Transaction = _trans.GetDbTransaction();
		return 0;
	}

	public async Task<code> Commit(){
		_trans.Commit();
		return 0;
	}

	public async Task<code> TxDropDict(str name){
		var bl = parseBl(name);
		_cmd.Parameters[$"@{nameof(KV.bl)}"].Value = nc(bl);
		await _cmd.ExecuteNonQueryAsync();
		return 0;
	}

	protected str parseBl(str name){
		return BlPrefix.parse(BlPrefix.dictYaml, name);
	}

	
}

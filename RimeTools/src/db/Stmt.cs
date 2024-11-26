using Microsoft.EntityFrameworkCore.Storage;

namespace db;

public class Stmt: IDisposable {
	public Stmt() {
	
	}

	~Stmt(){
		Dispose();
	}
	public void Dispose() {
	
	}

	public str sql { get; set; } = "";

	protected System.Data.Common.DbCommand _cmd_add;
	protected IDbContextTransaction _trans;

	public RimeDbContext dbCtx{get; set;} = new();
	public System.Data.Common.DbConnection conn{get; set;}
}


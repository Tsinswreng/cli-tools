using model;
using db;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace test.db;

public class TestEfCoreCustomSql{
	public static RimeDbContext dbCtx = new RimeDbContext();

	public static async Task GetLastId(){
		;var sql = "last_insert_rowid()"
		;
	}

}
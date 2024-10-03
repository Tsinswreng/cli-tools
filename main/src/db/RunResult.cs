namespace db;

public struct RunResult : I_RunResult{
	public i64 lastId{get;set;}
	public i64 affectedRows{get;set;}
	
}
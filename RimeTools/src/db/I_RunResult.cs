namespace db;


public interface I_lastId{
	i64 lastId{get;set;}
}

public interface I_affectedRows{
	i64 affectedRows{get;set;}
}

public interface I_RunResult: I_lastId, I_affectedRows{
	
}
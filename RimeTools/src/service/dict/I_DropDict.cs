namespace service.dict;

public interface I_DropDict{
	Task<code> DropDict(str dictName);
}

public interface I_Tx_DropDict: I_DropDict, IF.I_Transaction{
	
}


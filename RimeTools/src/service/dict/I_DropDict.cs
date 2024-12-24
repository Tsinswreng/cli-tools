namespace service.dict;

public interface I_DropDict{
	Task<zero> DropDict(str dictName);
}

public interface I_Tx_DropDict: IF.I_Transaction{
	Task<zero> TxDropDict(str dictName);
}


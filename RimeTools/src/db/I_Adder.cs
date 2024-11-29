namespace db;

public interface I_AdderAsync<T> : IF.I_Transaction{
	Task<I_lastId?> TxAdd(T entity);
}

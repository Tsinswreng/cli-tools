namespace db;

public interface I_TxAdderAsync<T> : IF.I_Transaction{
	Task<I_lastId?> TxAdd(T entity);
}

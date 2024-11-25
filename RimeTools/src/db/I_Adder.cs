namespace db;

public interface I_AdderAsync<T>{

	Task Begin();

	Task<I_lastId?> Add(T entity);

	Task Commit();
}

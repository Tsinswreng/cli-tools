namespace db;

public interface I_Adder<T>{

	Task Begin();

	Task<I_lastId> Add(T entity);

	Task Commit();
}

namespace IF;
public interface I_Transaction{
	Task<zero> Begin();
	Task<zero> Commit();
}
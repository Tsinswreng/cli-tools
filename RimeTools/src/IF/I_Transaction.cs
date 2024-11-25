namespace IF;
public interface I_Transaction{
	Task<code> Begin();
	Task<code> Commit();
}
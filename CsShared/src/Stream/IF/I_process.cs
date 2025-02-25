namespace Shr.Stream.IF;
public interface I_process<T> {
	/// <summary>
	/// 返非0則止
	/// </summary>
	Func<T, code> process { get; set; }
}

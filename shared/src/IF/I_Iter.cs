namespace Shr.Stream.IF;
public interface I_Iter<out T> {
	T getNext();
	bool hasNext();
}


public interface I_process<T> {
	/// <summary>
	/// 返非0則止
	/// </summary>
	Func<T, code> process { get; set; }
}



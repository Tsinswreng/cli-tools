namespace Shr.Stream.IF;
public interface I_Iter<out T> {
	T GetNext();
	bool HasNext();
}




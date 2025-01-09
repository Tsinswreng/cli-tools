namespace Shr.Stream.IF;
public interface I_Iter<out T> {
	T getNext();
	bool hasNext();
}




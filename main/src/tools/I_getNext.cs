namespace tools;

public interface I_getNext<out T>{
	T getNext();
	bool hasNext();
}
namespace IF;

public interface I_Iter<out T>{
    T getNext();
    bool hasNext();
}




public interface I_process<T>{
    Func<T, code> process { get; set; }
}
namespace Shr.IF;

public interface I_Segment<T>{
	/// <summary>
	/// 含
	/// </summary>
	public u64 start{get;set;}
	/// <summary>
	/// 含
	/// </summary>
	public u64 end{get;set;}

	public T data{get;set;}
}
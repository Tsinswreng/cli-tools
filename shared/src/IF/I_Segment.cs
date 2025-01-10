namespace Shr.IF;

public interface I_Segment<T>{
	/// <summary>
	/// 含
	/// </summary>
	public u64 Start{get;set;}
	/// <summary>
	/// 含
	/// </summary>
	public u64 End{get;set;}

	public T Data{get;set;}
}
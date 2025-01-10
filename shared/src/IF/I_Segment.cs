namespace Shr.IF;

public interface I_Segment<T>{
	/// <summary>
	/// 含
	/// </summary>
	public u8 Start{get;set;}
	/// <summary>
	/// 含
	/// </summary>
	public u8 End{get;set;}

	public T Data{get;set;}
}
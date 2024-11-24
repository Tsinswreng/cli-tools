namespace service.parser;

public interface I_LineCol{
	/// <summary>
	/// from 0
	/// </summary>
	public u64 line {get; set;}
	/// <summary>
	/// from 0
	/// </summary>
	public u64 col {get; set;}
}

public struct LineCol : I_LineCol{
	public u64 line {get; set;}
	public u64 col {get; set;}
}
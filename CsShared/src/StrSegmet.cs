namespace Shr;

public interface I_StrSegment{
	str text{get;set;}

	u64 start{get;set;}
}


public struct StrSegment: I_StrSegment{
	public str text{get;set;}
	public u64 start{get;set;}
}

using Shr.Parser.IF;

namespace Shr.Parser;

public struct Token:I_Token_u8Buf{
	public u64 Code{get;set;}
	public IList<u8> Data{get;set;}
	public u64 Start{get;set;}
	public u64 End{get;set;}
}
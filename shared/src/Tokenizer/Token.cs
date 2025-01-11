using Shr.Tokenizer.IF;

namespace Shr.Tokenizer;

public struct Token:I_Token{
	public u64 Code{get;set;}
	public IList<u8> Data{get;set;}
	public u64 Start{get;set;}
	public u64 End{get;set;}
}
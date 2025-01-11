using Shr.Tokenizer.IF;

namespace Shr.Tokenizer;

public struct Token:I_Token{
	public u64 code{get;set;}
	public IList<u8> data{get;set;}
	public u64 start{get;set;}
	public u64 end{get;set;}
}
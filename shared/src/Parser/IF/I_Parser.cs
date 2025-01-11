namespace Shr.Tokenizer.IF;

public interface I_Tokenizer{
	public I_Iter_Byte ByteIter{get;set;}
	public I_ParserState State{get;set;}
}
namespace Shr.Tokenizer.IF;

public interface I_Tokenizer{
	public I_Iter_Byte byteIter{get;set;}
	public I_TokenizerState state{get;set;}
}
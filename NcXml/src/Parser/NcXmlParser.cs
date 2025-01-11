using Shr.Tokenizer;
using Shr.Tokenizer.IF;
using static Shr.Tokenizer.Ext_Tokenizer;
namespace NcXml.Parser;


public class TokenizerState
	: Shr.Tokenizer.ParserState
{
	public IList<I_Token_u8Buf> Tokens = new List<I_Token_u8Buf>();
}

public class NcXmlTokenizer:
	I_Tokenizer
{

	public I_Iter_Byte ByteIter{get;set;}
	public I_ParserState State{get;set;} = new TokenizerState();

	public NcXmlTokenizer(I_Iter_Byte iter){
		ByteIter = iter;
	}

	public zero AddToken(I_Token_u8Buf token){
		((TokenizerState)State)
			.Tokens.Add(token);
		return 0;
	}

	public zero AddWhite(){
		var token = this.ReadWhite();
		AddToken(token);
		return 0;
	}

	public zero Start(){

		return 0;
	}





}
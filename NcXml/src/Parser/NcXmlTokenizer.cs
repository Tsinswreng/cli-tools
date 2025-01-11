using Shr.Tokenizer;
using Shr.Tokenizer.IF;
using static Shr.Tokenizer.Ext_Tokenizer;
namespace NcXml.Parser;


public class TokenizerState
	:Shr.Tokenizer.TokenizerState
{

}

public class NcXmlTokenizer
	:I_Tokenizer
{

	public I_Iter_Byte byteIter{get;set;}
	public I_TokenizerState state{get;set;} = new TokenizerState();

	public NcXmlTokenizer(I_Iter_Byte iter){
		byteIter = iter;
	}

	public IList<u8> lineComment{get;set;} = [(u8)'`']; // temp
	public IList<u8> trope{get;set;} = [(u8)'\\'];

	public zero addToken(I_Token token){
		(state)
			.tokens.Add(token);
		return 0;
	}

	public zero addWhite(){
		var z = this;
		var token = z.readWhite();
		z.addToken(token);
		return 0;
	}

	public zero Start(){
		var z = this;
		z.addWhite();
		var cur = (char)z.state.curChar;
		switch(cur){
			case '<':

			break;
			//case 單行註釋首字
			default:
				z.error("Unexpected character: " + cur);
			break;
		}
		return 0;
	}


	public zero HandleLineComment(){
		var z = this;
		return 0;
	}

	public zero HandleLAngleBracket(){
		var z = this;
		var lAngleBracket = new Token();
		lAngleBracket.data.Add(z.state.curChar);
		z.addToken(lAngleBracket);

		var white = z.readWhite();
		z.addToken(white);
		var cur = (char)z.state.curChar;
		switch(cur){
			//case '!':
		}
		return 0;
	}
}
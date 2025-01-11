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

	public I_Iter_Byte ByteIter{get;set;}
	public I_TokenizerState State{get;set;} = new TokenizerState();

	public NcXmlTokenizer(I_Iter_Byte iter){
		ByteIter = iter;
	}

	public IList<u8> LineComment{get;set;} = [(u8)'`']; // temp
	public IList<u8> Trope{get;set;} = [(u8)'\\'];

	public zero AddToken(I_Token token){
		(State)
			.Tokens.Add(token);
		return 0;
	}

	public zero AddWhite(){
		var z = this;
		var token = z.ReadWhite();
		z.AddToken(token);
		return 0;
	}

	public zero Start(){
		var z = this;
		z.AddWhite();
		var cur = (char)z.State.CurChar;
		switch(cur){
			case '<':

			break;
			//case 單行註釋首字
			default:
				z.Error("Unexpected character: " + cur);
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
		lAngleBracket.Data.Add(z.State.CurChar);
		z.AddToken(lAngleBracket);

		var white = z.ReadWhite();
		z.AddToken(white);
		var cur = (char)z.State.CurChar;
		switch(cur){
			//case '!':
		}
		return 0;
	}
}
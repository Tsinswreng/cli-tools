using Shr.Tokenizer.IF;
namespace Shr.Tokenizer;
using status_t = u64;
using word = u8;
// public interface ExtI_Parser{

// }

public static class Ext_Tokenizer{
	public static status_t statusCode_(this I_Tokenizer z){
		return z.state.statusCode;
	}

	public static zero statusCode_(this I_Tokenizer z, status_t status){
		z.state.statusCode = status;
		return 0;
	}



	public static bool hasNext(this I_Tokenizer z){
		return z.byteIter.hasNext();
	}

	public static word tryGetNextByteNoCheck(this I_Tokenizer z){
		var ans = z.byteIter.getNext();
		z.state.pos++;
		z.state.curChar = ans;
		return ans;
	}

	// public static word GetNextByte(this I_Parser z){
	// 	if(!z.HasNext()){

	// 	}
	// }

	/// <summary>
	///
	/// </summary>
	/// <param name="z"></param>
	/// <returns></returns>
	public static I_Token readWhite(this I_Tokenizer z){
		var ans = new Token();
		ans.code = 0;
		ans.start = z.state.pos;
		for(;z.hasNext();){
			var c = z.tryGetNextByteNoCheck();
			if(ParserUtil.isWhite(c)){
				ans.data.Add(c);
			}else{
				break;
			}
		}
		ans.end = z.state.pos;
		return ans;
	}

	public static Exception mkErr(this I_Tokenizer z, str msg){
		var err = new ParseErr(msg);
		err.pos = z.state.pos;
		return err;
	}

	public static zero error(this I_Tokenizer z, str msg){
		throw z.mkErr(msg);
	}



}
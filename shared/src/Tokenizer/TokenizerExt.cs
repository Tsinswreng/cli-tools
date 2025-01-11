using Shr.Tokenizer.IF;
namespace Shr.Tokenizer;
using status_t = u64;
using word = u8;
// public interface ExtI_Parser{

// }

public static class Ext_Tokenizer{
	public static status_t StatusCode_(this I_Tokenizer z){
		return z.State.StatusCode;
	}

	public static zero StatusCode_(this I_Tokenizer z, status_t status){
		z.State.StatusCode = status;
		return 0;
	}



	public static bool HasNext(this I_Tokenizer z){
		return z.ByteIter.HasNext();
	}

	public static word TryGetNextByteNoCheck(this I_Tokenizer z){
		var ans = z.ByteIter.GetNext();
		z.State.Pos++;
		z.State.CurChar = ans;
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
	public static I_Token ReadWhite(this I_Tokenizer z){
		var ans = new Token();
		ans.Code = 0;
		ans.Start = z.State.Pos;
		for(;z.HasNext();){
			var c = z.TryGetNextByteNoCheck();
			if(ParserUtil.IsWhite(c)){
				ans.Data.Add(c);
			}else{
				break;
			}
		}
		ans.End = z.State.Pos;
		return ans;
	}

	public static Exception MkErr(this I_Tokenizer z, str msg){
		var err = new ParseErr(msg);
		err.Pos = z.State.Pos;
		return err;
	}

	public static zero Error(this I_Tokenizer z, str msg){
		throw z.MkErr(msg);
	}



}
using Shr.Parser.IF;
namespace Shr.Parser;
using status_t = u64;
using word = u8;
public interface ExtI_Parser{

}

public static class Ext_Parser{
	public static status_t StatusCode_(this I_Parser z){
		return z.State.StatusCode;
	}

	public static zero StatusCode_(this I_Parser z, status_t status){
		z.State.StatusCode = status;
		return 0;
	}



	public static bool HasNext(this I_Parser z){
		return z.ByteIter.HasNext();
	}

	public static word TryGetNextByteNoCheck(this I_Parser z){
		var ans = z.ByteIter.GetNext();
		z.State.Pos++;
		z.State.CurChar = ans;
		return ans;
	}

	// public static word GetNextByte(this I_Parser z){
	// 	if(!z.HasNext()){

	// 	}
	// }

	public static I_Token_u8Buf ReadWhite(this I_Parser z){
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



}
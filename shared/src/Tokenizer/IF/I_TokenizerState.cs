namespace Shr.Tokenizer.IF;
using status_t = u64;
using word = u8;
public interface I_TokenizerState{
	/// <summary>
	/// from 0
	/// </summary>
	public u64 pos{get;set;}
	public word curChar{get;set;}
	public status_t statusCode{get;set;}
	public IList<status_t> statusStack{get;set;}
	/// <summary>
	/// 臨時存放
	/// </summary>
	public IList<word> buffer{get;set;}

	public IList<I_Token> tokens{get;set;}

}
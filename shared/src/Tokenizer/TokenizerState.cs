using Shr.Tokenizer.IF;

namespace Shr.Tokenizer;
using status_t = u64;
using word = u8;

public class TokenizerState:
	I_TokenizerState
{
	/// <summary>
	/// from 0
	/// </summary>
	public u64 pos{get;set;} = 0;
	public word curChar{get;set;}
	public status_t statusCode{get;set;} = 0;
	public IList<status_t> statusStack{get;set;} = new List<status_t>();
	/// <summary>
	/// 臨時存放
	/// </summary>
	public IList<word> buffer{get;set;} = new List<word>();

	public IList<I_Token> tokens{get;set;} = new List<I_Token>();

}
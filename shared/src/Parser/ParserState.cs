using Shr.Tokenizer.IF;

namespace Shr.Tokenizer;
using status_t = u64;
using word = u8;

public class ParserState:
	I_ParserState
{
	/// <summary>
	/// from 0
	/// </summary>
	public u64 Pos{get;set;} = 0;
	public word CurChar{get;set;}
	public status_t StatusCode{get;set;} = 0;
	public IList<status_t> StatusStack{get;set;} = new List<status_t>();
	/// <summary>
	/// 臨時存放
	/// </summary>
	public IList<word> Buffer{get;set;} = new List<word>();

}
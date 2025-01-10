namespace Shr.Parser.IF;
using status_t = u64;
using word = u8;
public interface I_ParserState{
	/// <summary>
	/// from 0
	/// </summary>
	public u64 Pos{get;set;}
	public word CurChar{get;set;}
	public status_t StatusCode{get;set;}
	public IList<status_t> StatusStack{get;set;}
	/// <summary>
	/// 臨時存放
	/// </summary>
	public IList<word> Buffer{get;set;}

}
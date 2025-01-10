using Shr.Text.IF;
using Shr.Parser.IF;
namespace Shr.Parser;

public class ParseError :
	Exception
	,I_ParseErr
{
	public ParseError(string message) :
		base(message)
	{
	}

	public u64? Pos{get;set;}
	public I_LineCol? LineCol{get;set;}
}
using Shr.Text.IF;
using Shr.Tokenizer.IF;
namespace Shr.Tokenizer;

public class ParseErr :
	Exception
	,I_ParseErr
{
	public ParseErr(string message) :
		base(message)
	{
	}

	public u64? Pos{get;set;}
	public I_LineCol? LineCol{get;set;}
}
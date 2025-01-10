using Shr.Text.IF;
namespace Shr.Parser.IF;

public interface I_ParseErr{
	public u64? Pos{get;set;}
	public I_LineCol? LineCol{get;set;}
}
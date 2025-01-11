using Shr.Text.IF;
namespace Shr.Tokenizer.IF;

public interface I_ParseErr{
	public u64? pos{get;set;}
	public I_LineCol? lineCol{get;set;}
}
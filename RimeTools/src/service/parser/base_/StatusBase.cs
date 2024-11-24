namespace service.parser.base_;

public class StatusBase: I_Status{
	public I_ParseState state{get;set;} = new ParseStateBase();
	public u64 pos{get;set;} = 0;
	public IList<I_ParseState> stack{get;set;} = new List<I_ParseState>();
	public u8 curByte{get;set;}
	public IList<u8> buffer{get;set;} = new List<u8>();
}

namespace service.parser.base_;

using IF;
using System.Text;

public interface I_ParseState{

}

public interface I_ParseError{
	public str Message{get;}
	public u64? pos{get;set;}
	public I_LineCol? lineCol{get;set;}
}

public interface I_Status{
	I_ParseState state{get;set;}
	u64 pos{get;set;}
	IList<I_ParseState> stack{get;set;}
	u8 curByte{get;set;}
	IList<u8> buffer{get;set;}
}

public interface I_Parser: I_Iter<u8>{
	I_Status status{get;set;}
	Encoding encoding{get;set;}
	//bool eq(u8 ch1, unknown ch2);
}

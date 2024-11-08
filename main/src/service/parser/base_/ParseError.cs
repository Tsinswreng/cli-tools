namespace service.parser.base_;

public class ParseError: Exception, I_ParseError{
	public ParseError(str msg){
		Message = msg;
	}
	public override str Message{get;}
	public u64? pos{get;set;}
	public I_LineCol? lineCol{get;set;}
}


using service.parser.base_;
using Shr.Stream.IF;

namespace service.parser;

public class TsvParser: ParserBase{
	public TsvParser(I_Iter<u8> byteReader): base(byteReader){
		
	}
}
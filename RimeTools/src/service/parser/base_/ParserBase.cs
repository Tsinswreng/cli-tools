using System.Text;
using Shr;
using Shr.Stream.IF;
namespace service.parser.base_;


public class ParseStatus{


}

public class ParserBase: I_Parser{

	public ParserBase(I_Iter<u8> byteReader){
		this.byteReader = byteReader;
	}

	public I_Status status{get;set;} = new StatusBase();
	public Encoding encoding{get;set;} = Encoding.UTF8;
	public I_Iter<u8> byteReader{get;set;}

	public u8 getNext(){
		return byteReader.getNext();
	}

	public bool hasNext(){
		return byteReader.hasNext();
	}

	public code error(str msg){
		var err = new ParseError(msg);
		throw err;
	}

	public bool eq(u8 ch1, u8 ch2){
		return ch1 == ch2;
	}

	public bool eq(u8 ch1, char ch2){
		return ch1 == ch2;
	}

	public str bufToStr(IList<u8> buf){
		return encoding.GetString(buf.ToArray());
	}

	public I_StrSegment bufToStrSegEtClr(){
		var start = status.pos - (u64)status.buffer.Count;
		var text = bufToStr(status.buffer);
		status.buffer.Clear();
		return new StrSegment{
			start = start
			,text = text
		};
	}

}

using Shr.Parser;
using Shr.Parser.IF;
using static Shr.Parser.Ext_Parser;
namespace NcXml.Parser;


public class ParserState
	: Shr.Parser.ParserState
{

}

public class NcXmlParser:
	I_Parser
{

	public I_Iter_Byte ByteIter{get;set;}
	public I_ParserState State{get;set;} = new ParserState();

	public NcXmlParser(I_Iter_Byte iter){
		ByteIter = iter;
	}


	
}
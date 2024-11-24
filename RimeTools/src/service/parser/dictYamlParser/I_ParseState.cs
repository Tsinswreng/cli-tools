namespace service.parser.dictYamlParser;


public interface I_ParseState{
	public str? curLine{get; set;}
	/// from 0
	public int lineNum {get; set;}// = -1;
	public State state {get; set;}// = State.start;

	/** from 0
	 * ---往後一行、不含---
	 */
	public i32 metadataBeginLine {get; set;}// = -1;
	
	/**
	 *  from 0
	 * 不含...
	 */
	public i32 metadataEndLine {get; set;}// = -1;

	//public List<str> metadataLines {get; set;} = new List<str>();
	public model.DictMetadata? metadata{get; set;}
}
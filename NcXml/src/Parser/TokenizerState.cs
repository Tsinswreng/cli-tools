namespace NcXml.Parser;

using S = i32;

public class ParseState{
	static protected ParseState _inst = null!;
	public static ParseState getInst(){
		if(_inst == null){
			_inst = new ParseState();
		}
		return _inst;
	}

	protected static i32 i = 1;


	public S TopSpace = i++;
	public S PropertyStr = i++;
	public S Tag = i++;
}


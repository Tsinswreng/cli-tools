namespace Shr.Tokenizer;

using S = i32;

public class TokenizerStateCode{
	static protected TokenizerStateCode _inst = null!;
	public static TokenizerStateCode getInst(){
		if(_inst == null){
			_inst = new TokenizerStateCode();
		}
		return _inst;
	}

	protected static i32 i = 0;


	// public S TopSpace = i++;
	// public S PropertyStr = i++;
	// public S Tag = i++;
}





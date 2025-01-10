namespace NcXml.Parser;

using System.Diagnostics.Contracts;
using System.Text;
using state_t = i32;
using word = byte;


public static class Ext_IList{
	public static code tryPop<T>(this IList<T> z, out T rtn){
		if(z.Count == 0){
			rtn = default!;
			return -1;
		}
		rtn = z[z.Count - 1];
		z.RemoveAt(z.Count - 1);
		return 0;
	}

	public static T? peek<T>(this IList<T> z){
		if(z.Count == 0){
			return default;
		}
		return z[z.Count - 1];
	}
}
//s
public class Status{
	public state_t state = ParseState.getInst().TopSpace;
	public IList<state_t> stack = new List<state_t>();
	public u64 pos {get;set;} = 0;
	public word curChar {get; set;} = default;
	public IList<word> buffer {get; set;} = new List<word>();

}

public class XmlPp{

	protected Status _status = new();
	public state_t state{
		get{
			return _status.state;
		}
		set{
			_status.state = value;
		}
	}

	protected ParseState stateEnum = ParseState.getInst();


	//讀ʹ果ˇ存
	public IList<word> buffer{
		get{
			return _status.buffer;
		}
	}

	public word curChar{
		get{
			return _status.curChar;
		}
	}

	I_nextU8 nextU8; //TODO

	public Encoding encoding{get; set;} = Encoding.UTF8;

	protected zero error(str msg){
		throw new Exception(msg);
	}

	protected word getNextU8Unchecked(){
		var ans = nextU8.getNext();
		_status.pos++;
		_status.curChar = ans;
		return ans;
	}

	protected word getNextU8(u64? pos = null){
		if(!hasNext()){
			var errMsg = "Unexpected EOF";
			if(pos != null){
				errMsg += $"from {pos}";
			}
			error(errMsg);
			return default!;
		}
		return getNextU8Unchecked();
	}

	protected bool hasNext(){
		return nextU8.hasNext();
	}


	protected bool eq(word s1, char s2){
		return s1 == s2;
	}

	protected bool eq(word s1, word s2){
		return s1 == s2;
	}

	protected bool isWhite(word s){
		if( eq(s , ' ') ){return true;}
		if( eq(s , '\t') ){return true;}
		if( eq(s , '\n') ){return true;}
		if( eq(s , '\r') ){return true;}
		return false;
	}

	public zero skipWhite(){
		var pos = _status.pos;
		for(;;){
			var c = getNextU8(pos);
			if( !isWhite(c) ){
				break;
			}
		}
		return 0;
	}

	public IList<word> readUntil(word target, bool required){
		var pos = _status.pos;
		var buf = new List<word>();
		for(;;){
			if(!hasNext()){
				if(required){
					error($"Unexpected EOF from {pos}");
				}
				return buf;
			}
			var c = getNextU8(pos);
			if( c == target ){
				return buf;
			}
			buf.Add(c);
		}
		//return buf;
	}

	public IList<word> readDoubleQuote(IList<word> buf){
		//cur char is '"' and state is PropertyStr
		//_status.buffer.Add(curChar);
		//var buf = new List<word>();
		buf.Add(curChar);
		for(;hasNext();){
			var c = (char)getNextU8();
			switch(c){
				case '"':
					// _status.stack.tryPop(out var neo);
					// state = neo;
					buf.Add((word)c);
				return buf;
			}
			buf.Add((word)c);
		}
		return buf;
	}

	public IList<word> readTag(){
		//cur char is '<'
		var buf = new List<word>();
		buf.Add(curChar);
		for(;hasNext();){
			var c = (char)getNextU8();
			switch(c){
				case '"':
					readDoubleQuote(buf);
				break;
			}
			buf.Add((word)c);
		}
		return buf;
	}

	//public

	public zero parse(){
		for(;hasNext();){
			var c = (char)getNextU8();
			switch(c){
				case '<':
				break;
				default:
					_status.buffer.Add((word)c);
				continue;
			}
			// if(c == '<'){
			// 	state = stateEnum.Tag;
			// 	_status.stack.Add(state);
			// 	continue;
			// }
			// if(c == '>'){
			// 	if(_status.stack.peek() == stateEnum.Tag){
			// 		_status.stack.tryPop(out var neo);
			// 		state = neo;
			// 	}
			// 	continue;
			// }
			// if(c == '"'){
			// 	if(_status.stack.peek() == stateEnum.Tag){
			// 		state = stateEnum.PropertyStr;
			// 		_status.stack.Add(state);
			// 		continue;
			// 	}
			// 	if(_status.stack.peek() == stateEnum.PropertyStr){
			// 		_status.stack.tryPop(out var neo);
			// 		state = neo;
			// 		continue;
			// 	}
			// }

			// if(c == '#'){

			// }

		}

		return 0;
	}

	// public IList<word> readTag(){
	// 	//cur char is '<'
	// 	for(;;){
	// 		var c = (char)getNextU8();
	// 		switch(c){
	// 			case '>':
	// 			break;
	// 		}
	// 	}
	// }



}
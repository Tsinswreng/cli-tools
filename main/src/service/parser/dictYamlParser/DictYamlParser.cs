namespace service.parser.dictYamlParser;

public class ParseState{
	/** from 0 */
	public int lineNum {get; set;} = 0;
	public State state {get; set;} = State.start;

	/** from 0 */
	public i32 metadataBeginLine {get; set;} = -1;
	
	/** from 0 */
	public i32 metadataEndLine {get; set;} = -1;
}


public class DictYamlParser{
	DictYamlParser(str src, I_LineReader lineReader){
		this.src = src;
		this.lineReader = lineReader;
	}

	public str src {get; set;}

	public I_LineReader lineReader {get; set;}

	public ParseState state {get; set;} = new ParseState();

	public static str rmLineComment(str line){
		int index = line.IndexOf("#");
		if(index >= 0){
			line = line.Substring(0, index);
		}
		return line;
	}

	protected async Task<str?> ReadLine(){
		str? line = await lineReader.ReadLine();
		return line;
	}

	protected async void start(){
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}
			state.lineNum++;
			if(line == "---"){
				state.state = State.metadata;
				state.lineNum++;
				break;
			}
		}
	}

	protected async void metadata(){
		state.metadataBeginLine = state.lineNum;
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}
			state.lineNum++;
			if(line == "..."){
				state.state = State.metadata;
				break;
			}
		}
	}

	protected void body(){

	}
	

	public async Task Parse(){
		state.lineNum = 0;
		state.state = State.start;
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}
			state.lineNum++;
			switch (state.state){
				case State.start:
					start();
				break;

				case State.metadata:
					metadata();
				break;

				case State.body:
					body();
				break;

			}
			// switch (line){
			// 	case "---":
			// 		state.state = State.Metadata;
			// 	break;
			// }
		}
	}
}

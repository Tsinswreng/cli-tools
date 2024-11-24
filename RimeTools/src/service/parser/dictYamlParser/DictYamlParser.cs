using model;

namespace service.parser.dictYamlParser;

// TODO 叶 #no comment
public class ParseState: I_ParseState{
	public str? curLine{get; set;}
	/// from 0
	public int lineNum {get; set;} = -1;
	public State state {get; set;} = State.start;

	/** from 0
	 * ---往後一行、不含---
	 */
	public i32 metadataBeginLine {get; set;} = -1;
	
	/**
	 *  from 0
	 * 不含...
	 */
	public i32 metadataEndLine {get; set;} = -1;

	public List<str> metadataLines {get; set;} = new List<str>();

	public DictMetadata? metadata {get;set;}
}

/* 

function(
	cb: (str:string) => any
){
//...
}
上面的代碼用c#如何實現?
要求 cb既能接收有返回值的函數、也能接收void的函數。
 */


public class DictYamlParser{
	public DictYamlParser(
		I_ReadLine lineReader
		,Func<I_ParseState, object> onBodyLine
	){
		//this.src = src;
		this.lineReader = lineReader;
		this.onBodyLine = onBodyLine;
	}

	//public str src {get; set;}

	public I_ReadLine lineReader {get; set;}

	public ParseState state {get; set;} = new ParseState();

	public Func<ParseState, unknown> onBodyLine {get; set;} = (parseState)=>{return 0;};

	public Func<DictMetadata, unknown> onMetadata {get; set;} = (meta)=>{return 0;};


	/// <summary>
	/// 
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	public static str rmLineComment(str line){
		int index = line.IndexOf("#");
		if(index >= 0){
			line = line.Substring(0, index);
		}
		return line;
	}

	public str _rmLineComment(str line){
		return rmLineComment(line);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="metadataStr"></param>
	/// <returns></returns>
	protected DictMetadata parseMetadata(str metadataStr){
		var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().Build();
		var metadata = deserializer.Deserialize<DictMetadata>(metadataStr);
		state.metadata = metadata;
		onMetadata(metadata);
		return metadata;
	}

	/// <summary>
	/// get next line and update state
	/// </summary>
	/// <returns></returns>
	protected async Task<str?> ReadLine(){
		str? line = await lineReader.ReadLine();
		state.curLine = line;
		if(line == null){
			return null;
		}
		state.lineNum++;
		return line;
	}

	protected async Task Start(){
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}

			if(line == "---"){
				state.state = State.hyphen3;
				break;
			}
		}
	}

	protected async Task Metadata(){
		state.metadataBeginLine = state.lineNum+1; // ---往後一行
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}
			state.metadataLines.Add(line);
			if(line == "..."){
				state.metadataEndLine = state.lineNum-1;
				state.state = State.dot3;
				break;
			}
		}
	}

	protected async Task Body(){
		while(true){
			str? line = await ReadLine();
			if(line == null){
				state.state = State.end;
				break;
			}
			//var noComment = rmLineComment(line);
			onBodyLine(state);
		}
	}


	protected async Task Hyphen3(){
		state.state = State.metadata;
	}

	protected async Task Dot3(){
		var metadata = string.Join("\n", state.metadataLines);
		parseMetadata(metadata);
		state.state = State.body;
	}
	

	public async Task Parse(){
		state.lineNum = -1;
		state.state = State.start;
		var timeToBreak = false;
		for(var i = 0; true ;i++){
			// str? line = await ReadLine();
			// if(line == null){
			// 	state.state = State.end;
			// 	break;
			// }
			// state.lineNum++;
			switch (state.state){
				case State.start:
					await Start();
				break;

				case State.metadata:
					await Metadata();
				break;

				case State.body:
					await Body();
				break;

				case State.hyphen3:
					await Hyphen3();
				break;

				case State.dot3:
					await Dot3();
				break;
				
				case State.end:
					timeToBreak = true;
				break;
			}
			if(timeToBreak){
				break;
			}
		}//~for
	}
}



// public class Program
// {
//     // 定义一个委托，接受一个字符串参数并返回一个 object
//     public delegate object Callback(string str);

//     public static void Main()
//     {
//         // 调用函数，传入一个返回值的回调
//         ExecuteCallback(ReturnValueCallback);

//         // 调用函数，传入一个 void 的回调
//         ExecuteCallback(VoidCallback);
// 		ExecuteCallback((txt)=>{return "";});
//     }

//     // 函数接受一个 Callback 类型的参数
//     public static void ExecuteCallback(Callback cb)
//     {
//         // 调用回调函数
//         object result = cb("Hello, World!");
        
//         // 输出结果
//         if (result != null)
//         {
//             Console.WriteLine("Callback returned: " + result);
//         }
//     }

//     // 返回值的回调函数
//     public static string ReturnValueCallback(string str)
//     {
//         return str.ToUpper(); // 返回字符串的大写形式
//     }

//     // void 的回调函数
//     public static object VoidCallback(string str)
//     {
//         Console.WriteLine("Void callback received: " + str);
//         return null; // 返回 null 表示没有返回值
//     }
// }

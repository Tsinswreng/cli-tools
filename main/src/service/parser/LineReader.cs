/* =異步逐行讀文件、叶I_LineReader */
using System.Text;
namespace service.parser;

public class LineReader: I_LineReader{

	public LineReader(str path):this(path, Encoding.UTF8){
		
	}

	public LineReader(str path, Encoding encoding){
		this.path = path;
		reader = new StreamReader(path, encoding);
	}

	//protected

	public str path{get;set;}

	public StreamReader reader{get;set;}

	public async Task<str?> ReadLine(){
		return await reader.ReadLineAsync();
	}
}
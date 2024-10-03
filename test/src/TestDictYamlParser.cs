using service.parser;
using service.parser.dictYamlParser;

namespace test;

public class TestDictYamlParser{
	public static async Task _Main(){
		var path = "E:/_code/ngaq/src/backend/dict/原表/dkp.dict.yaml";
		var parser = new DictYamlParser(
			new LineReader(path, std.Text.Encoding.UTF8)
			, (txt) => {
				System.Console.WriteLine(txt);
				return 0;
			}
		);
		await parser.Parse();
		
		// }
		// Func<bool, object> fn = (txt)=>{
		// 	System.Console.WriteLine(txt);
		// 	return 0; //无法将类型“int”隐式转换为“string”CS0029
		// };
		
	}
}

using model;
using service;
using service.parser;
using service.parser.dictYamlParser;

namespace ctrler;

public class AddDictInDb{

	public static async Task lineStrToModel(str line){
		
	}
	
	public static async Task Run(string dictPath){
		I_LineReader lineReader = new LineReader(dictPath);
		var dictYamlParser = new DictYamlParser(
			lineReader
			, (txt) => {
				//TODO add in db
				return 0;
			}
		);

	}

}
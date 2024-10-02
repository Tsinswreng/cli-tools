using model;
using service;
using service.parser;
using service.parser.dictYamlParser;

namespace ctrler;

public class AddDictInDb{

	protected DictMetadata? metadata {get;set;}
	protected I_lineStrToKVs? lineStrToKVs;

	protected i32 _initDeps(DictMetadata metadata){
		this.metadata = metadata;
		lineStrToKVs = new DictLineParser(metadata);
		return 0;
	}

	public DictLineKVs lineStrToModel(str line){
		return lineStrToKVs!.lineStrToKVs(line);
	}

	

	public async Task AddKVs(KV[] kvs){
		using(var ctx = new db.RimeDbContext()){

			//await ctx.KVEntities.AddRangeAsync(kvs);
		}
	}
	
	public async Task Run(string dictPath){
		I_LineReader lineReader = new LineReader(dictPath);
		var dictYamlParser = new DictYamlParser(
			lineReader
			, (state) => {
				//TODO add in db
				if(metadata == null){
					_initDeps(G.nn(state.metadata));
				}
				
				return 0;
			}
		);

		

	}

}
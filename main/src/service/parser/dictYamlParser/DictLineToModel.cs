using model;
using model.consts;
using VT = model.consts.ValueType;
namespace service.parser.dictYamlParser;



public class DictLineToModel 
: I_parseLineStr{
	//需要 metadata

	public DictMetadata? metadata {get;set;}

	public i32 setMetadata(DictMetadata metadata){
		this.metadata = metadata;
		return 0;
	}

	public List<KV> convert(DictLine line) {
		var text__code = new KV();
		text__code.kStr = line.text;
		text__code.vType = VT.TEXT.ToString();
		if(metadata?.name == null){
			throw new Exception("metadata.name is null");
		}
		text__code.bl = BlPrefix.dictYaml+BlPrefix.delimiter+metadata.name;
		text__code.vDesc = ValueDesc.text.ToString();

		var text__weight = new KV();



		return null;//TODO

	}

	public DictLine parseLineStr(str line){
		var items = line.Split("\t");
		if(metadata == null){
			var ans = new DictLine();
			ans.text = items[0]??"";
			ans.code = items[1]??"";
			ans.weight = items[2]??"";
			return ans;
		}else{
			//TODO
			throw new NotImplementedException();
		}
	}

}
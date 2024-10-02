using model;
using model.consts;
using VT = model.consts.KVType;
namespace service.parser.dictYamlParser;



public class DictLineParser
: I_parseLineStr, I_parseLineObj, I_lineStrToKVs{
	//需要 metadata

	public DictLineParser(DictMetadata metadata){
		this.metadata = metadata;
	}


	public DictMetadata metadata {get;set;}

	public i32 setMetadata(DictMetadata metadata){
		this.metadata = metadata;
		return 0;
	}


	protected i32 setBl(KV kv){
		if(metadata == null){
			throw new Exception("metadata is null");
		}
		kv.bl = BlPrefix.dictYaml+BlPrefix.delimiter+metadata.name;
		return 0;
	}

	/* 
少	stewʔ	90%
{	//字-碼
	id: 0
	,bl: "dict.yaml:dks"
	,kType: "TEXT"
	,kStr: "少"
	,kDesc: "text"
	,vType: "TEXT"
	,vStr: "stewʔ"
	,vDesc: "code"
}
	 */
	protected KV toText__codeKV(in DictLine line){
		var text__code = new KV();
		text__code.kStr = line.text;
		text__code.vType = VT.STR.ToString();
		// if(metadata?.name == null){
		// 	throw new Exception("metadata.name is null");
		// }
		// text__code.bl = BlPrefix.dictYaml+BlPrefix.delimiter+metadata.name;
		setBl(text__code);
		text__code.vDesc = VDesc.text.ToString();
		return text__code;
	}

/* 
少	stewʔ	90%
{	//頻--字-碼
	id:1
	,bl: "dict.yaml:dks"

	,kType: "INT"
	,kInt: 0
	,kDesc: "fKey"
	
	,vType: "TEXT"
	,vStr: "90%"
	,vDesc: "weight"
}
 */
	protected KV? toFKey__WeightKV(in DictLine line){
		if(line.weight == ""){
			return null;
		}
		var fKey__weight = new KV();
		//fKey__weight.kInt = 0; text__codeˇ加入表後取lastId作其值
		if(i64.TryParse(line.weight, out i64 weightI64)){//整數weight 作i64
			fKey__weight.vI64 = weightI64;
		}else{ //帶百分號之weight (ex: 10%) 作字串
			fKey__weight.vStr = line.weight;
		}
		setBl(fKey__weight);
		fKey__weight.kDesc = KDesc.fKey.ToString();
		fKey__weight.vDesc = VDesc.weight.ToString();
		fKey__weight.vType = VT.STR.ToString();
		return fKey__weight;
	}



	// public List<KV> convert(DictLine line) {
	// 	var weight = new KV();
	// 	if(i64.TryParse(line.weight, out i64 weightInt)){ //整數weight 作i64
	// 		weight.vI64 = weightInt;
	// 	}else{ //帶百分號之weight (ex: 10%) 作字串
	// 		weight.vStr = line.weight;
	// 	}
	// 	return null;//TODO
	// }

	//ref readonly 
	public DictLineKVs parseLineObj(in DictLine line){
		var text__code = toText__codeKV(line);
		var fKey__weight = toFKey__WeightKV(line);
		if(fKey__weight == null){
			return new DictLineKVs(text__code);
		}
		return new DictLineKVs(text__code, fKey__weight);
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

	public DictLineKVs lineStrToKVs(str line){
		var lineObj = parseLineStr(line);
		var kvs = parseLineObj(lineObj);
		return kvs;
	}

}
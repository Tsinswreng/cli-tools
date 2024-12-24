using service;
using service.phraseMker;
namespace ctrler;



public class DksMkPhrase: IDisposable{


	public str yamlHead{get;set;} = 
"""
---
name: dks_phrase
version: ""
sort: by_weight
columns:
  - text
  - code
  - weight
use_preset_vocabulary: false
...
""";

	public str dstPath{get;set;} = "D:/Program Files/Rime/User_Data/dks_phrase.dict.yaml";
	public str srcPath{get;set;} = "D:/Program Files/Rime/User_Data/dks.dict.yaml";

	public str dictName{get;set;} = "dks";

	public DksMkPhrase() {
		phraseMkr = new MkPhrase(line=>{
			exput("\n");
			exput(line.text);
			exput("\t");
			exput(line.code);
			exput("\t");
			exput(line.weight);
			return 0;
		}, "dks");
	}

	~DksMkPhrase(){
		Dispose();
	}
	public void Dispose() {
	
	}

	public I_PhraseMkr phraseMkr{get;set;}

	protected code exput(str x){
		System.Console.Write(x);
		return 0;
	}

	//new DksMkPhrase().start();
//dotnet publish -c Release 
// ./bin/Release/net8.0/RimeTools.exe > "D:/Program Files/Rime/User_Data/dks_phrase.dict.yaml"
	public async Task<code> start(){
		await new DictManager().ReaddDict(dictName, srcPath);
		exput(yamlHead);
		exput("\n");
		return phraseMkr.start();
	}

}



/// <summary>
/// 用只取首碼與次碼之造詞策略
/// </summary>
[Obsolete]
public class DksMkPhrase12: IDisposable {
	public DksMkPhrase12() {
		phraseMkr = new MkPhrase(line=>{
				exput("\n");
				exput(line.text);
				exput("\t");
				exput(line.code);
				exput("\t");
				exput(line.weight);
				return 0;
			}
			,"dks"
		);
		phraseMkr.phraseMkr = new PhraseMker_HeadEtSecond();
	}

	~DksMkPhrase12(){
		Dispose();
	}
	public void Dispose() {
	
	}

	public I_PhraseMkr phraseMkr{get;set;}

	protected code exput(str x){
		System.Console.Write(x);
		return 0;
	}

	//new DksMkPhrase().start();
	// dotnet run -c Release > dks_phrase.txt
	public code start(){
		return phraseMkr.start();
	}

}

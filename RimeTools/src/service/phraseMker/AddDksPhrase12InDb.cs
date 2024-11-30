using db;
using IF;
using model;
using service.dict;
using service.parser.dictYamlParser;

namespace service.phraseMker;
public class MkEtAddPhraseInDb: IDisposable, I_Transaction, I_dictName{
	public MkEtAddPhraseInDb(str dictName) {
		this.dictName = dictName;
		phraseMkr = new service.MkPhrase(line=>{
			
			return 0;
		},dictName);

		phraseMkr.phraseMkr = new PhraseMker_HeadEtSecond();
	}

	~MkEtAddPhraseInDb(){
		Dispose();
	}
	public void Dispose() {
	
	}

	public I_PhraseMkr phraseMkr{get;set;}

	public I_TxAdderAsync<DictLineKVs> dictLineKVsAdder{get;set;} = new DictLineKVsAdder();

	public I_dictLineToDictLineKVs dictLineToDictLineKVs{get;set;} = new DictLineParser();

	public str dictName{get;set;} = "dks";

	public async Task<code> Begin(){
		await dictLineKVsAdder.Begin();
		return 0;
	}

	public async Task<code> Commit(){
		await dictLineKVsAdder.Commit();
		return 0;
	}

	protected async Task<code> _handleLine(DictLine line){
		var dictLineKVs = dictLineToDictLineKVs.dictLineToDictLineKVs(line);
		await dictLineKVsAdder.TxAdd(dictLineKVs);
		return 0;
	}

}

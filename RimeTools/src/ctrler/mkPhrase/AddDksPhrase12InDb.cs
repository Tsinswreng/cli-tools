using service;
using service.dict;
using service.phraseMker;

namespace ctrler.mkPhrase;


public class AddPhraseInDb: IDisposable {
	public AddPhraseInDb() {
		phraseMkr = new service.MkPhrase(line=>{

			return 0;
		},"dks");

		phraseMkr.phraseMkr = new PhraseMker_HeadEtSecond();
	}

	~AddPhraseInDb(){
		Dispose();
	}
	public void Dispose() {
	
	}

	public I_PhraseMkr phraseMkr{get;set;}

	public DictLineKVsAdder dictLineKVsAdder{get;set;} = new DictLineKVsAdder();

}

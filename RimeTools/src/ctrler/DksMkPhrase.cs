using service;
using service.phraseMker;
namespace ctrler;



public class DksMkPhrase: IDisposable {
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
	// dotnet run -c Release > dks_phrase.txt
	public code start(){
		return phraseMkr.start();
	}

}

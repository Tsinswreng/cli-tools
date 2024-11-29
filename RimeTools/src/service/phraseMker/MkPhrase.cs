using IF;
using model;
using service;
using service.phraseMker;

//TODO 遷至service下
namespace service;


class Splitter: I_SplitByCodePoint{
	//TODO temp impl
	public IList<str> splitByCodePoint(str str){
		var ans = new List<str>();
		for(int i=0; i<str.Length; i++){
			ans.Add(str[i].ToString());
		}
		return ans;
	}
}


public class MkPhrase: I_PhraseMkr{

	public MkPhrase(Func<DictLine, code> dictLineHandler, string dictName){
		this.process = dictLineHandler;
		this.dictName = dictName;
		this.codeSeeker = new ReverseLookup(dictName);
	}

	public I_Iter<I_KV> wordFreqReader{get;set;} = (I_Iter<I_KV>)new WordFreqReader();
	public I_mkPhrase phraseMkr{get;set;} = new PhraseMker_HeadEtTail();

	public str dictName{get;set;}
	
	public I_seekCode codeSeeker{get;set;}

	public Func<DictLine, code> process{get;set;}

	protected I_SplitByCodePoint _splitter = new Splitter();

	public code start(){
		var word__code__freq_s = new List< List<str> >();// [str, str, str][]
		for(var i = 0;wordFreqReader.hasNext();i++){
			var wordFreq = wordFreqReader.getNext();
			if(wordFreq == null){break;}
			var word = wordFreq.kStr; //單字或詞 以 「車輛」 潙例
			if(word == null || word==""){continue;}
			var freq = wordFreq.vI64;
			var wordList = _splitter.splitByCodePoint(word??"");// ["車","輛"]
			var codes = codeSeeker.seekCode(wordList);//[ ["che1","liang4"], ["ju1", "liang4"] ]
			if(codes.Count == 0){
				continue;
			}
			var u_word__code__freq = new List<str>();// [str, str, str]
			for(var j = 0; j < codes.Count; j++){
				var codeList = codes[j]; // ["che1","liang4"]
				var phraseCode = phraseMkr.mkPhrase(codeList);// 假設無処理: ["che1","liang4"]
				if(phraseCode == null || phraseCode.Count == 0){
					continue;
				}
				var joinedPhraseCode = string.Join("", phraseCode); // "che1liang4"
				var ua = new List<str>(){word??"", joinedPhraseCode, freq?.ToString()??""};// ["車輛", "che1liang4", "1000"]
				var uDictLine = new DictLine(){
					text = word??""
					,code = joinedPhraseCode
					,weight = freq?.ToString()??""
				};
				var ans = process(uDictLine);
				if(ans!=0){
					return ans;
				}
				//u_word__code__freq.Add(string.Join("\t", ua));
			}
			//word__code__freq_s.Add(u_word__code__freq);
		}
		return 0;
	}
}
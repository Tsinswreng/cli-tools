using model;
using service;
using service.phraseMker;
using tools;
namespace ctrler;


public class Splitter: I_SplitByCodePoint{
	//TODO temp impl
	public IList<str> splitByCodePoint(str str){
		var ans = new List<str>();
		for(int i=0; i<str.Length; i++){
			ans.Add(str[i].ToString());
		}
		return ans;
	}
}

/// <summary>
/// temp 
/// </summary>
public class MkPhrase{

	public MkPhrase(){

	}

	protected I_getNext<I_KV> _wordFreqReader = (I_getNext<I_KV>)new WordFreqReader();
	protected I_mkPhrase _phraseMkr = new PhraseMker_HeadEtTail();
	protected I_seekCode _codeSeeker = new ReverseLookup();

	protected I_SplitByCodePoint _splitter = new Splitter();

	public code mkPhrase(){
		var word__code__freq_s = new List< List<str> >();
		for(var i = 0;_wordFreqReader.hasNext();i++){
			var wordFreq = _wordFreqReader.getNext();
			if(wordFreq == null){break;}
			var word = wordFreq.kStr;
			if(word == null){continue;}
			var freq = wordFreq.vI64;
			var wordList = _splitter.splitByCodePoint(word??"");
			var codes = _codeSeeker.seekCode(wordList);
			if(codes.Count == 0){
				continue;
			}
			var u_word__code__freq = new List<str>();
			for(var j = 0;j<codes.Count;j++){
				var codeList = codes[j];
				var phraseCode = _phraseMkr.mkPhrase(codeList);
				if(phraseCode == null || phraseCode.Count == 0){
					continue;
				}
				var joinedPhraseCode = string.Join("", phraseCode);
				var ua = new List<str>(){word??"", joinedPhraseCode, freq?.ToString()??""};
				u_word__code__freq.Add(string.Join("\t", ua));
			}
			word__code__freq_s.Add(u_word__code__freq);
		}
		for(var i = 0;i<word__code__freq_s.Count;i++){
			var u_word__code__freq = word__code__freq_s[i];
			for(var j = 0;j<u_word__code__freq.Count;j++){
				var line = u_word__code__freq[j];
				Console.WriteLine(u_word__code__freq[j]);
			}
		}
		return 0;
	}
}
using model;
using tools;

namespace service.phraseMker;

/// <summary>
/// 造詞策略
/// </summary>
public interface I_mkPhrase{
	/// <summary>
	/// 設策略潙 取每字首末兩碼 車輛:: fn(["che", "liang"], ["車", "輛"])
	/// -> ["ce", "lg"]
	/// chars 可省
	/// </summary>
	/// <param name="codes"></param>
	/// <returns></returns>
	IList<str> mkPhrase(IList<str> codes, IList<str>? chars = null);
}



/// <summary>
/// 造詞器
/// </summary>
public interface I_PhraseMkr{
	/// <summary>
	/// 流式讀八股文
	/// </summary>
	public I_getNext<I_KV> wordFreqReader{get;set;}
	/// <summary>
	/// 造詞策略
	/// </summary>
	public I_mkPhrase phraseMkr{get;set;}
	/// <summary>
	/// 尋碼策略
	/// </summary>
	public I_seekCode codeSeeker{get;set;}
	/// <summary>
	/// 流式處理結果
	/// </summary>

	public Func<DictLine, code> dictLineHandler{get;set;}

	public code start();

	public str dictName{get;set;}

}
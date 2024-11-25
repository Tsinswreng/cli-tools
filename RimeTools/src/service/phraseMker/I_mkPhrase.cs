namespace service.phraseMker;

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
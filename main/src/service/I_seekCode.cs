namespace service;

public interface I_seekCode{
	/// <summary>
	/// 由單字尋碼 fn("車") -> ["che1","ju1"] ; fn("輛") -> ["liang4"]
	/// </summary>
	/// <param name="dzvs"></param>
	/// <returns></returns>
	IList<str> seekCode(str dzvs);

	/// <summary>
	/// 由多字尋碼 fn(["車", "輛"]) -> 
	/// [ ["che1","liang4"], ["ju1", "liang4"] ]
	/// </summary>
	/// <param name="tshvq"></param>
	/// <returns></returns>
	IList< IList<str> > seekCode(IList<str> tshvq);
}
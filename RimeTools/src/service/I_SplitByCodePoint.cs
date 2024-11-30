namespace service;

public interface I_SplitByCodePoint{
	/// <summary>
	/// "a漢𠂇😍" -> ["a", "漢", "𠂇", "😍"]
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	IList<str> splitByCodePoint(str str);
}

/* =異步讀取一行文字 */
namespace service.parser;

public interface I_LineReader{
	Task<str?> ReadLine();
}


//
namespace Shr.Tokenizer;

public static class ParserUtil{
	public static bool eq(u8 a, u8 b){
		return a == b;
	}

	public static bool eq(char a, char b){
		return a == b;
	}

	public static bool eq(str a, str b){
		return a == b;
	}

	public static bool eq(u8 a, char b){
		return (char)a == b;
	}

	public static bool eq(char a, u8 b){
		return a == (char)b;
	}

	public static bool eq<T>(T a, T b){
		return EqualityComparer<T>.Default.Equals(a, b);
	}


	public static bool isWhite(u8 a){
		var c = (char)a;
		return c == ' ' || c == '\t' || c == '\n' || c == '\r';
	}

}
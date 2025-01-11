//
namespace Shr.Tokenizer;

public static class ParserUtil{
	public static bool Eq(u8 a, u8 b){
		return a == b;
	}

	public static bool Eq(char a, char b){
		return a == b;
	}

	public static bool Eq(str a, str b){
		return a == b;
	}

	public static bool Eq(u8 a, char b){
		return (char)a == b;
	}

	public static bool Eq(char a, u8 b){
		return a == (char)b;
	}

	public static bool Eq<T>(T a, T b){
		return EqualityComparer<T>.Default.Equals(a, b);
	}


	public static bool IsWhite(u8 a){
		var c = (char)a;
		return c == ' ' || c == '\t' || c == '\n' || c == '\r';
	}

}
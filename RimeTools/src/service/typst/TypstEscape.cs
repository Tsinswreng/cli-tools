using Shr.Stream.IF;
using System.Collections;

namespace service.typst;

public class TypstEscape{


	public TypstEscape(I_Iter<u8> byteReader){
		this.byteReader = byteReader;
	}
	//除了數字和字母外的所有可打印ascii字符
	public static HashSet<char> symbols = [
		' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
		':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'
	];

	public I_Iter<u8> byteReader{get;set;}

	public u8 escaper {get;set;} = (u8)'\\';

	public u8[] escape(u8 c){
		u8[] ans = [escaper, c];
		return ans;
	}

	public IList<u8> parse(){
		var ans = new List<u8>(0x100);
		while(byteReader.hasNext()){
			var b = byteReader.getNext();
			if(symbols.Contains((char)b)){
				ans.AddRange(escape(b));
			}else if(eq(b, '\n')){
				ans.Add(b);
				ans.Add((u8)' ');
				ans.Add((u8)'\\'); //  \  爲換行
				ans.Add((u8)' ');
			}else{
				ans.Add(b);
			}
		}
		return ans;
	}

	public bool eq(u8 a, char b){
		return (char)a == b;
	}
}
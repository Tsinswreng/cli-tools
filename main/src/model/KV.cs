using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using model.consts;

namespace model;

public interface I_KV{

	/** TEXT, INT */
	public str kType {get; set;}
	public str? kStr {get; set;}
	public i64? kI64 {get; set;}
	//public str KeyType {get; set;} = "";

	public str? kDesc {get; set;}

	public str vType {get; set;}

	public str? vDesc {get; set;}

	//[Column("str")]
	public str? vStr {get; set;}
	//[Column("int")]
	public i64? vI64 {get; set;}

	public f64? vF64 {get; set;}


}


//[Table("KV")]
public class KV : IdBlCtUt, I_KV {
	/** TEXT, INT */
	public str kType {get; set;} = KVType.STR.ToString(); 
	public str? kStr {get; set;}
	public i64? kI64 {get; set;}
	//public str KeyType {get; set;} = "";

	public str? kDesc {get; set;}

	public str vType {get; set;}= KVType.STR.ToString();

	public str? vDesc {get; set;}

	//[Column("str")]
	public str? vStr {get; set;}
	//[Column("int")]
	public i64? vI64 {get; set;}

	public f64? vF64 {get; set;}
}


/* 
能不能寫一個源生成器、把類或結構體轉成Dictionary<string, object>

比如
public class Rectangle{
	public string Name {get; set;}
	public int x {get; set;}
	public int y {get; set;}
	public int square(){
		return x * y;
	}
}

變成->
public class Dict{
	public static Dictionary<string, object> toDict(Rectangle rect){
		Dictionary<string, object> dict = new Dictionary<string, object>();
		dict["Name"] = rect.Name;
		dict["x"] = rect.x;
		dict["y"] = rect.y;
		rect["square"] = (Dictionary<string, object> self) => {return self["x"] * self["y"];}
		return dict;
	}
}


Dictionary<string, object> rect = new Dictionary<string, object>();
rect["Name"] = "Rectangle";
rect["x"] = 10;
rect["y"] = 20;
//rect["square"] = new Func<int>(rect.square);
rect["square"] = (Dictionary<string, object> self) => {return self["x"] * self["y"];}
 */
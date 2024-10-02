using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model;

[Table("KV")]
public class KV : IdBlCtUt {
	
	/** TEXT, INT */
	public str kType {get; set;} = "TEXT"; 
	public str kStr {get; set;} = "";
	public i64? kInt {get; set;}
	//public str KeyType {get; set;} = "";

	public str kDesc {get; set;} = "";

	public str vType {get; set;} = "";

	public str vDesc {get; set;} = "";

	//[Column("str")]
	public str vStr {get; set;} = "";
	//[Column("int")]
	public i64? vI64 {get; set;}

	public f64? vF64 {get; set;}
}


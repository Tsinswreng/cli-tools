using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model;

[Table("KV")]
public class KV : IdBlCtUt {
	
	public str Key {get; set;} = "";
	//public str KeyType {get; set;} = "";

	public str KeyDesc {get; set;} = "";

	public str VauleType {get; set;} = "";

	public str ValueDesc {get; set;} = "";


	public str Str {get; set;} = "";
	public i64? Int {get; set;}
	public f64? Real {get; set;}
}
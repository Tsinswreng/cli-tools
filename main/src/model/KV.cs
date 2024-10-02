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
	public i64? vInt {get; set;}

	public f64? vReal {get; set;}
}


/* 

少	stewʔ	90%
少	stews	10%

->

{
	id: 0
	,bl: "dict.yaml:dks"
	,key: "少"
	,keyDesc: "text"
	,vauleType: "TEXT"
	,str: "stewʔ"
	,valueDesc: "code"
}

{
	id: 1
	,bl: "dict.yaml:dks"
	,key: ""
}

#

辣	rˁat	99999999
 */
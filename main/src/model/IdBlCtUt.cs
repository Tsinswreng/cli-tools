using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model;

public class IdBlCtUt{
	[Key]
	
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public i64 id {get; set;}
	
	public str? bl {get; set;}
	
	public i64 ct {get; set;} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
	public i64 ut {get; set;} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}

//It is just difficult at the beginning
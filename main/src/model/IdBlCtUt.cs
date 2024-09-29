using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model;

public class IdBlCtUt{
	[Key]
	
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public i64 Id {get; set;}
	[Required]
	public str Bl {get; set;} = "";
	
	public i64 Ct {get; set;} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
	public i64 Ut {get; set;} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}

//It is just difficult at the beginning
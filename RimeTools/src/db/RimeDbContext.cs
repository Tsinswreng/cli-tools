using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using model;
using model.consts;

namespace db;

public class RimeDbContext : DbContext{
	public DbSet<KV> KV { get; set; }
	public DbSet<WordFreq> WordFreq { get; set; }

	protected code _configKV<T>(ModelBuilder mb) where T : class, I_KV {

		mb.Entity<T>().HasIndex(e => e.kStr);
		mb.Entity<T>().HasIndex(e => e.kI64);
		mb.Entity<T>().HasIndex(e => e.kDesc);

		mb.Entity<T>().Property(e=>e.kType).HasDefaultValue(KVType.STR.ToString());
		mb.Entity<T>().Property(e=>e.vType).HasDefaultValue(KVType.STR.ToString());
		return 0;
	}

	protected code _configIdBlCtUt<T>(ModelBuilder mb) where T : class, I_IdBlCtUt {
		mb.Entity<T>().HasKey(e=>e.id);
		mb.Entity<T>().Property(e=>e.id).ValueGeneratedOnAdd();
		mb.Entity<T>().HasIndex(e => e.bl);
		mb.Entity<T>().HasIndex(e => e.ct);
		mb.Entity<T>().HasIndex(e => e.ut);
		mb.Entity<T>().Property(e=>e.ct).HasDefaultValueSql("(strftime('%s', 'now') || substr(strftime('%f', 'now'), 4))");
		mb.Entity<T>().Property(e=>e.ut).HasDefaultValueSql("(strftime('%s', 'now') || substr(strftime('%f', 'now'), 4))");
		return 0;
	}

	protected override void OnModelCreating(ModelBuilder mb){
		base.OnModelCreating(mb);
		// 這裡可以進行進一步的配置，例如設置主鍵、索引等

//DatabaseGenerated(DatabaseGeneratedOption.Identity)

		//KV
		mb.Entity<KV>().ToTable("KV");
		_configIdBlCtUt<KV>(mb);
		_configKV<KV>(mb);
		// 以上三句 都不會報錯

		//WordFreq
		mb.Entity<WordFreq>().ToTable("WordFreq");
		_configIdBlCtUt<WordFreq>(mb);
		_configKV<WordFreq>(mb);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
		// 在這裡配置您的數據庫連接字符串
		var path = G.getBaseDir()+"/"+"RimeTools"+"/db/db.sqlite";
		optionsBuilder.UseSqlite($"Data Source={path}");
	}

	public Task<IDbContextTransaction> BeginTrans(){
		return Database.BeginTransactionAsync();
	}
}



//dotnet ef migrations add InitialCreate
//dotnet ef database update

// 創建遷移
// dotnet ef migrations add _20241104214647_add_WordFreq

// 移除未使用的遷移
// dotnet ef migrations remove

// 回滾到指定遷移
// dotnet ef database update InitialCreate

/*
ts的class-transformer庫是直接把轉換邏輯函數寫進裝飾器裏的
如
class User {
	@Transform(value => moment(value))
	time:Moment
}

c#的映射庫是怎麼做的?
*/

//AutoMapper:

/*
using AutoMapper;

public class User
{
	public DateTime Time { get; set; }
}

public class UserDto
{
	public string Time { get; set; }
}

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<User, UserDto>()
			.ForMember(
				dest => dest.Time
				, opt => opt.MapFrom(src => src.Time.ToString("o"))
			); // ISO 8601 格式
	}
}

// 使用示例
var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
var mapper = config.CreateMapper();

var user = new User { Time = DateTime.Now };
var userDto = mapper.Map<UserDto>(user);

*/


/*
using Newtonsoft.Json;
using System;

public class User
{
	[JsonConverter(typeof(CustomDateTimeConverter))]
	public DateTime Time { get; set; }
}

public class CustomDateTimeConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var dateTime = (DateTime)value;
		writer.WriteValue(dateTime.ToString("o")); // ISO 8601 格式
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var dateTimeString = (string)reader.Value;
		return DateTime.Parse(dateTimeString);
	}

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(DateTime);
	}
}

// 使用示例
var user = new User { Time = DateTime.Now };
var json = JsonConvert.SerializeObject(user);
var deserializedUser = JsonConvert.DeserializeObject<User>(json);

*/
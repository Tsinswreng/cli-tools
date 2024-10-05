using ctrler;
namespace test.ctrler;

public class TestAddDksToDb{
	public static async Task _Main(){
		var dksPath = "d:/Program Files/Rime/User_Data/dks_v.dict.yaml";
		var addDictInDb = new AddDictInDb();
		
		await addDictInDb.AddFromPath(dksPath);
	}
}
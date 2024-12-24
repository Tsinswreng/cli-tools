using service.dict;

namespace service;

public class DictManager
	: I_DropDict
	, I_AddFromPath
{
	public I_Tx_DropDict dictDropper = new DictDropper();
	public I_AddFromPath dictAdder = new AddDictInDb();

	//await new DictManager().AddDictFromPath("D:/Program Files/Rime/User_Data/dks.dict.yaml");
	public Task<int> AddFromPath(string path){
		return dictAdder.AddFromPath(path);
	}

	public async Task<zero> DropDict(string dictName){
		await dictDropper.Begin();
		await dictDropper.TxDropDict(dictName);
		return await dictDropper.Commit();
	}

	//await new DictManager().ReaddDict("dks_v", "D:/Program Files/Rime/User_Data/dks_v.dict.yaml");
	public async Task<code> ReaddDict(str dictName, str path){
		await DropDict(dictName);
		return await AddFromPath(path);
		//return 0;
	}
}
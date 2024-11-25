using service.dict;

namespace service;

public class DictManager
	: I_DropDict
	, I_AddFromPath
{
	public I_DropDict dictDropper = new DictDropper();
	public I_AddFromPath dictAdder = new AddDictInDb();

	public Task<int> AddFromPath(string path){
		return dictAdder.AddFromPath(path);
	}

	public Task<int> DropDict(string dictName){
		return dictDropper.DropDict(dictName);
	}

	public async Task<code> ReaddDict(str dictName, str path){
		await DropDict(dictName);
		return await AddFromPath(path);
	}

}
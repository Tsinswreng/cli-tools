namespace ctrler;

public class DictManager{
	public service.DictManager dictManager = new();
	public Task<code> ReaddDict(str dictName, str path){
		return dictManager.ReaddDict(dictName, path);
	}

	public async Task<code> AddDictFromPath(str path){
		await dictManager.AddFromPath(path);
		return 0;
	}
}


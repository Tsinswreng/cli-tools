namespace ctrler;

public class DictManager{
	public service.DictManager dictManager = new();
	public Task<code> ReaddDict(str dictName, str path){
		return dictManager.ReaddDict(dictName, path);
	}
}
namespace model;

public struct DictLineKVs{
	public DictLineKVs(KV text__code, KV? fKey__weight=null){
		this.text__code=text__code;
		this.fKey__weight=fKey__weight;
	}
	public KV text__code{get;set;}
	public KV? fKey__weight{get;set;}
}
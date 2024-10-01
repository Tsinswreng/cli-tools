/** =.dict.yaml正文中的每一行的结构 */
namespace model;

public struct DictLine{
	public DictLine(){
		
	}
	public DictLine(
		str text
		,str code
		,str weight
	){
		this.text=text;
		this.code=code;
		this.weight=weight;
	}
	public str text{get;set;}="";
	public str code{get;set;}="";
	public str weight{get;set;}="";
}
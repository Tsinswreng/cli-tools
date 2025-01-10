using System.Text.RegularExpressions;

namespace NcXml;


public class PathEtText{
	public string path{get;set;} = "";
	public string text{get;set;} = "";
}


public class ParseNcXml{
	public Conf conf{get;set;} = Conf.inst;//Unused

	public str parse(str text){
		text = Regex.Replace(text, "`.*$", "", RegexOptions.Multiline);//TODO 寫死
		return text;
	}
}

public class ParseFile{
	public ParseNcXml parseNcXml{get;set;} = new();

	public str affix{get;set;} = ".nc.xml";

	public zero parse(str path){
		var text = File.ReadAllText(path);
		var result = parseNcXml.parse(text);

		var neoPath = path.Substring(0, path.Length - affix.Length);
		File.WriteAllText(neoPath, result);
		return 0;
	}
}


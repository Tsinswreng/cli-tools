
namespace NcXml;

public class Conf{
	// src: myFile.xml.nsign.xml -> dst: myFile.xml
	// src: myFile.axaml.nsign.xml -> dst: myFile.axml
	protected static Conf _inst = null!;
	[Obsolete]
	public static Conf inst{
		get{
			if(_inst == null){
				_inst = new Conf();
			}
			return _inst;
		}
	}

	public static Conf getInst(){
		if(_inst == null){
			_inst = new Conf();
		}
		return _inst;
	}

	/// <summary>
	/// index.html.nc.xml -> index.html
	/// </summary>
	public str suffix{get;set;} = ".nc.xml";

	public str lineComment{get;set;} = "`";

	// \\ -> \
	// \` -> `
	public bool backSlashTrope{get;set;} = true;
}
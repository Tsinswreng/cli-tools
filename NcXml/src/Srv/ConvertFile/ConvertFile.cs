using System.Text.RegularExpressions;
using NcXml.Srv.ConvertFile.IF;
using System.IO;
using Shr.IO.Filum;
namespace NcXml.Srv.ConvertFile;

/// <summary>
/// temp impl
/// </summary>
public class NcXmlConverter
	:I_convertNcXmlFile
	,I_convertNcXmlFileName
{
	#region impl
	public zero convertFile(string inputFile, string outputFile){
		var imput = File.ReadAllText(inputFile);
		var output = Parse(imput);
		Filum.Ensure(outputFile);
		File.WriteAllText(outputFile, output);
		return 0;
	}

	/// <summary>
	/// index.html.nc.xml -> index.html
	/// </summary>
	/// <param name="inputFile"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public str convertFileName(string inputFile){
		var suffix = Conf.getInst().suffix;
		var head = inputFile.Substring(0, inputFile.Length - suffix.Length);
		var tail = inputFile.Substring(inputFile.Length - suffix.Length);
		if(tail != suffix){
			throw new ArgumentException("invalid file name");
		}
		return head;
	}

	#endregion impl


	protected NcXmlConverter(){}

	public static readonly NcXmlConverter inst = new NcXmlConverter();
	public static NcXmlConverter GetInst(){
		return inst;
	}


	public str Parse(str text){
		text = Regex.Replace(text, "`.*$", "", RegexOptions.Multiline);
		return text;
	}



}
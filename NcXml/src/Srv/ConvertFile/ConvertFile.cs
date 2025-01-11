using System.Text.RegularExpressions;
using NcXml.Srv.ConvertFile.IF;
using System.IO;
namespace NcXml.Srv.ConvertFile;

/// <summary>
/// temp impl
/// </summary>
public class NcXmlConverter
	:I_ConvertFile
{
	#region impl
	public zero ConvertFile(string inputFile, string outputFile){
		File.ReadAllText(inputFile);
		return 0;
	}

	#endregion impl


	public str Parse(str text){
		text = Regex.Replace(text, "`.*$", "", RegexOptions.Multiline);
		return text;
	}



}
namespace NcXml.Srv.ConvertFile.IF;

public interface I_convertNcXmlFile{
	public zero convertFile(string inputFile, string outputFile);
}


public interface I_convertNcXmlFileName{
	/// <summary>
	/// index.html.nc.xml -> index.html
	/// </summary>
	/// <param name="inputFile"></param>
	/// <returns></returns>
	public str convertFileName(string inputFile);
}
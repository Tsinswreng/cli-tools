using NcXml.Srv;
using NcXml.Srv.ConvertFile;
using NcXml.Srv.ConvertFile.IF;
namespace NcXml.Ctrler;

public class WatcherConverter
	:IDisposable
{

	public WatcherConverter(str path){
		this.path = path;
		watcher = new FileSystemWatcher();
		_initWatcher();
		ncXmlConverter = _ncXmlConverterImpl;
		ncXmlFileNameConverter = _ncXmlConverterImpl;
		searchPattern = "*"+Conf.getInst().suffix;
	}

	public void Dispose(){
		watcher?.Dispose();
	}

	~WatcherConverter(){
		Dispose();
	}

	public str path{get;set;}

	public FileSystemWatcher watcher{get;set;}

	protected NcXmlConverter _ncXmlConverterImpl{get;set;} = NcXmlConverter.GetInst();

	public I_convertNcXmlFile ncXmlConverter{get;set;}
	public I_convertNcXmlFileName ncXmlFileNameConverter{get;set;}
	public str searchPattern{get;set;}

	protected zero _initWatcher(){
		watcher.Path = path;
		watcher.Filter = searchPattern; // "*.nc.xml";
		watcher.IncludeSubdirectories = true;
		watcher.NotifyFilter = NotifyFilters.LastWrite;
		return 0;
	}

	public zero initCompile(){
		var srcFiles = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
		foreach (var srcFile in srcFiles){
			var targetPath = ncXmlFileNameConverter.convertFileName(srcFile);
			ncXmlConverter.convertFile(srcFile, targetPath);
		}
		return 0;
	}

	public zero start(){
		initCompile();
		var watcher = this.watcher;
		watcher.Changed += (a,b)=>{
			//System.Console.WriteLine("File changed: " + b.FullPath);
			try{
				System.Threading.Thread.Sleep(100);
				var txt = File.ReadAllText(b.FullPath);
				var targetPath = ncXmlFileNameConverter.convertFileName(b.FullPath);
				ncXmlConverter.convertFile(b.FullPath, targetPath);
				//System.Console.WriteLine(txt);
			}
			catch (System.Exception e){
				System.Console.WriteLine(e);
			}
		};
		watcher.EnableRaisingEvents = true;
		return 0;
	}
}
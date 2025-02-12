using NcXml.Ctrler;

/*
dotnet run -- "E:/_code/cli-tools/NcXml/test"
 */

//TODO
var help = @"Usage: <ExeName> <dir>
";

if(args[0] == null || args[0] == ""){
	Console.WriteLine(help);
	return;
}
var watcher = new WatcherConverter(args[0]);
watcher.start();
for(;;){
	Console.ReadLine();
}

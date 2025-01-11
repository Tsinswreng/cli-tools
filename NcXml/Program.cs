using NcXml.Ctrler;

/*
dotnet run -- "E:/_code/cli-tools/NcXml/test"
 */
var watcher = new WatcherConverter(args[0]);
watcher.start();
for(;;){
	Console.ReadLine();
}

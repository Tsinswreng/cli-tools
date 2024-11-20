using System;
using System.IO;
using System.Linq;

class Program{public static int Main(string[] args){
	
if(args.Length < 3){
	System.Console.WriteLine("<srcDir> <dstDir> <text>");
	return 1;
}

var srcDir = args[0];
var dstDir = args[1];
var text = args[2];

var files = Directory.EnumerateFiles(srcDir, "*.*", SearchOption.AllDirectories);

foreach(var file in files){
	System.Console.WriteLine(file);
}


return 0;


}}

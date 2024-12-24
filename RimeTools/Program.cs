// See https://aka.ms/new-console-template for more information


using ctrler;

Console.OutputEncoding = std.Text.Encoding.UTF8;



await new DksMkPhrase().start();

// dotnet run -c Release < "D:/Program Files/Rime/User_Data/dks_phrase.dict.yaml"  470983
//dotnet run -c Release < "E:/_code/cli-tools/RimeTools/dks_phrase12.txt" 398814
// var map = new Dictionary<str, u64>();
// using (StreamReader reader = new StreamReader(Console.OpenStandardInput())){
// 	string allInput = reader.ReadToEnd();
// 	var lines = allInput.Split('\n');
// 	for(var i = 0; i < lines.Length; i++){
// 		var line = lines[i];
// 		if(!map.ContainsKey(line)){
// 			map.Add(line, 0);
// 		}
// 	}
// 	System.Console.WriteLine(map.Count);
// }

//new MkPhrase().mkPhrase();
//await new DictManager().AddDictFromPath("D:/Program Files/Rime/User_Data/dks.dict.yaml");
//test.TestLevelDb._Main();

//new DksMkPhrase12().start();

//await new DictManager().AddDictFromPath("D:/Program Files/Rime/User_Data/dks_phrase.dict.yaml");



/* 
in Person.d.ts:
export interface Person{
	name: string;
	age: number;
	sayHello():number
}

in c#:
//@type{Person}
Dictionary<string, object> person = new();

person["name"] = "John";
person["age"] = 30;
person["sayHello"] = (Dictionary<string, object> self)=>{
	G.log("Hello, " + self["name"] + "!");
	return 0;
};


int age = (int)person["age"];

 */
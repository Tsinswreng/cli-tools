#define DEBUG
namespace test;


/* 
cd /e/_code/rime-tools/test && dotnet test --filter "FullyQualifiedName~test.UnitTest1.Test1" --logger "console;verbosity=detailed"
 */
public class UnitTest1{
	[Fact] 
	public async void Test1(){
		Console.OutputEncoding = std.Text.Encoding.UTF8;
		//await test.ctrler.TestAddDksToDb._Main();
		System.Console.WriteLine(
			G.getBaseDir()
			//E:\_code\rime-tools\test\bin\Debug\net8.0\
		);
		//System.Console.WriteLine("done");
		//System.Console.WriteLine("漢漢漢一二三四五六七八九十");
		// if(double.TryParse("5%", out double result)){
		// 	System.Console.WriteLine(result);
		// }else{
		// 	System.Console.WriteLine("parse failed");
		// }
	
		System.Console.WriteLine("____________________________________________________");
	}
}


// class Person{
// 	string name = "name";
// 	void testRef(ref Person p){
// 		p.name = "new name";
// 	}

// 	void testNoRef(Person p){
// 		p.name = "new name";
// 	}
// }




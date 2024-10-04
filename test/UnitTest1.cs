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

		//await test.db.TestEfCoreBatchAdd.AddRange();
		;await test.db.TestEfCoreBatchAdd.AddWithLastId3();
		
	
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




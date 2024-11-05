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
		//TestLevelDb._Main();

		//await test.db.TestEfCoreBatchAdd.AddRange();
		//;await test.db.TestEfCoreBatchAdd.AddWithRawSql();
		
		//[1,2],[3],[4,5],[6]
		var arr = new List<List<i32>>{
				new List<i32>{1,2}
				,new List<i32>{3}
				,new List<i32>{4,5}
				,new List<i32>{6}
			};
		var ans = tools.Tools.cartesianProduct(
			arr
		);
		
		G.logJson(ans);
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




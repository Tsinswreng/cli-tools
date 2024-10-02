namespace test;


/* 
cd /e/_code/rime-tools/test && dotnet test --filter "FullyQualifiedName~test.UnitTest1.Test1" --logger "console;verbosity=detailed"
 */
public class UnitTest1{
	[Fact] 
	public async void Test1(){
		Console.OutputEncoding = std.Text.Encoding.UTF8;
		//TestParseDictMetadata.Main_();
		// List<int> a = [1,2,3];
		// System.Console.WriteLine();
		//await TestDictYamlParser._Main();

		//System.Console.WriteLine("done");
		//System.Console.WriteLine("漢漢漢一二三四五六七八九十");
		if(double.TryParse("5%", out double result)){
			System.Console.WriteLine(result);
		}else{
			System.Console.WriteLine("parse failed");
		}


		
		System.Console.WriteLine("____________________________________________________");
	}
}




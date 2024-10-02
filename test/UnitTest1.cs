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
		// if(double.TryParse("5%", out double result)){
		// 	System.Console.WriteLine(result);
		// }else{
		// 	System.Console.WriteLine("parse failed");
		// }
		var s1 = new String("abc");
		var s2 = "abc";
		string s3 = "abc";
		System.Console.WriteLine(s1 == s2); //O(n)、比較值 true

		System.Console.WriteLine(
			object.ReferenceEquals(s1, s2) //O(1)、比較引用 false
		);

		System.Console.WriteLine(
			object.ReferenceEquals(s2, s3) //O(1)、比較引用 true
		);

		System.Console.WriteLine("____________________________________________________");
	}
}




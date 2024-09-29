namespace test;


//dotnet test --filter "FullyQualifiedName~test.UnitTest1.Test1" --logger "console;verbosity=detailed"
public class UnitTest1{
	[Fact] 
	public async void Test1(){
		await AsyncReadLine.Main();
	}
}




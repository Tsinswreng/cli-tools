namespace test;

//dotnet test --filter "FullyQualifiedName~test.UnitTest1.Test1" --logger "console;verbosity=detailed"
public class UnitTest1
{
    [Fact] 
    public void Test1()
    {
		Console.WriteLine("Hello, World!");
		var myVar = 1;
		System.Console.WriteLine(nameof(myVar));
    }
}



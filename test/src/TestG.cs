namespace test;

/* 
cd /e/_code/rime-tools/test && dotnet test --filter "FullyQualifiedName~test.TestG" --logger "console;verbosity=detailed"
 */
public class TestG {
	[Fact]
	public void internStr1(){
		str literal = "abc";
		str neoString = new String("abc");
		Assert.True(
			literal == neoString
		);

		Assert.True(
			!G.refEq(literal, neoString)
		);
	}


	[Fact]
	public void internStr2(){
		str literal = "abc";
		str neoString = new String("abc");
		G.internStr(ref neoString);
		Assert.True(
			literal == neoString
		);

		Assert.True(
			G.refEq(literal, neoString)
		);
	}
}
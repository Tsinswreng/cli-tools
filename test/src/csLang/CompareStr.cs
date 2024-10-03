/* 
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

	for(;;){
		var str_ = Console.ReadLine();
		str_ = string.Intern(str_??"");
		System.Console.WriteLine(str_);
		System.Console.WriteLine(object.ReferenceEquals(str_, "abc"));
		//System.Console.WriteLine(G.lstrEq(str_, "abc"));
	}


 */
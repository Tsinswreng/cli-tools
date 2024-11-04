// See https://aka.ms/new-console-template for more information
Console.OutputEncoding = std.Text.Encoding.UTF8;










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
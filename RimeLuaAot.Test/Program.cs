// See https://aka.ms/new-console-template for more information
using RimeLuaAot.Windows;

Console.WriteLine("Hello, World!");

System.Console.WriteLine(
	WinClipBoard.GetText()
);

WinClipBoard.SetText("ab一二𠂇😍");

System.Console.WriteLine(
	WinClipBoard.GetText()
);

﻿// **************************************************
// Solution (1) - New in .NET 6
// **************************************************
// در صورتی که در هنگام ایجاد
// یک پروژه، گزینه ذیل را غیر فعال کنیم
// Do not use top-level statesments
// **************************************************
//System.Console.WriteLine("Hello World!");
// **************************************************
// /Solution (1)
// **************************************************

// **************************************************
// Solution (2)
// **************************************************
// توصیه می‌شود که نام پارامترهای
// توابع را در هنگام فراخوانی اعلام نموده و بنویسیم
// **************************************************
//System.Console.WriteLine(value: "Hello World!");
// **************************************************
// /Solution (2)
// **************************************************

// **************************************************
// Solution (3) - Default until .NET 5
// **************************************************
// در صورتی که در هنگام ایجاد یک
// پروژه، گزینه ذیل را فعال کنیم
// Do not use top-level statesments
// **************************************************
//namespace Application
//{
//	internal class Program
//	{
//		static void Main(string[] args)
//		{
//			System.Console.WriteLine("Hello World!");
//		}
//	}
//}
// **************************************************
// /Solution (3)
// **************************************************

// **************************************************
// Solution (4)
// **************************************************
// قانون مهم
// هر آن‌چه ننویسیم، کامپایلر آن‌را می‌نویسید
// و یا برداشت می‌کند را به صراحت می‌نویسیم
// **************************************************
//namespace Application
//{
//	internal static class Program : object
//	{
//		static Program()
//		{
//		}

//		private static void Main()
//		{
//			System.Console.WriteLine(value: "Hello World!");
//		}
//	}
//}
// **************************************************
// /Solution (4)
// **************************************************

// **************************************************
// Solution (5)
// **************************************************
namespace Application;

internal static class Program : object
{
	static Program()
	{
	}

	private static void Main()
	{
		System.Console.WriteLine(value: "Hello World!");
	}
}
// **************************************************
// /Solution (5)
// **************************************************
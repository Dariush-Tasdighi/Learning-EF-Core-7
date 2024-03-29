﻿// **************************************************
// Solution (0)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		System.Console.WriteLine
//			(value: $"Max Value of 'int': {int.MaxValue:#,##0}");

//		System.Console.WriteLine
//			(value: $"Max Value of 'long': {long.MaxValue:#,##0}");
//	}
//}
// **************************************************
// /Solution (0)
// **************************************************

// **************************************************
// Solution (1)
// **************************************************
//namespace Application;

///// <summary>
///// CRUD:
///// C -> Create | U -> Update | D -> Delete | R -> Retrieve
/////
///// Retrieve:
/////		Zero or One
/////		Zero Or Many
///// </summary>
//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//	}

//	private static void CreateCategory()
//	{
//		Models.DatabaseContext databaseContext = new Models.DatabaseContext();

//		Models.Category category = new Models.Category();

//		category.Name = "My Category";

//		databaseContext.Categories.Add(category);

//		databaseContext.SaveChanges();
//	}
//}
// **************************************************
// /Solution (1)
// **************************************************

// **************************************************
// Solution (2)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//		HowToCreateAnObject();
//	}

//	private static void HowToCreateAnObject()
//	{
//		// **************************************************
//		//int x;
//		//x = 1;

//		//int x = 1;

//		//// Compile Error!
//		//var x;
//		//x = 1;

//		//var x = 1;
//		//var y = "Dariush";

//		//// Compile Error!
//		//var x = null;
//		// **************************************************

//		// **************************************************
//		//Models.Person person = new Models.Person();

//		//person.FullName = "Dariush Tasdighi";
//		//person.Age = 50;
//		// **************************************************

//		// **************************************************
//		//Models.Person person = new();

//		//person.FullName = "Dariush Tasdighi";
//		//person.Age = 50;
//		// **************************************************

//		// **************************************************
//		//var person = new Models.Person();

//		//person.FullName = "Dariush Tasdighi";
//		//person.Age = 50;
//		// **************************************************

//		// **************************************************
//		//var person = new Models.Person() { FullName = "Dariush Tasdighi", Age = 20 };
//		// **************************************************

//		// **************************************************
//		//var person =
//		//	new Models.Person()
//		//	{
//		//		FullName = "Dariush Tasdighi",
//		//		Age = 50
//		//	};
//		// **************************************************

//		// **************************************************
//		//var person =
//		//	new Models.Person
//		//	{
//		//		FullName = "Dariush Tasdighi",
//		//		Age = 50
//		//	};
//		// **************************************************

//		// **************************************************
//		//var person =
//		//	new Models.Person
//		//	{
//		//		FullName = "Dariush Tasdighi",
//		//		Age = 50,
//		//	};
//		// **************************************************

//		// **************************************************
//		var person =
//			new Models.Person
//			{
//				Age = 50,
//				FullName = "Dariush Tasdighi",
//			};
//		// **************************************************
//	}

//	private static void CreateCategory()
//	{
//		// **************************************************
//		var databaseContext = new Models.DatabaseContext();
//		//Models.DatabaseContext databaseContext = new Models.DatabaseContext();
//		// **************************************************

//		// **************************************************
//		var category =
//			new Models.Category
//			{
//				Name = "My Category",
//			};

//		//Models.Category category = new Models.Category();
//		//category.Name = "My Category";
//		// **************************************************

//		//databaseContext.Categories.Add(category);
//		databaseContext.Categories.Add(entity: category);

//		databaseContext.SaveChanges();
//	}
//}
// **************************************************
// /Solution (2)
// **************************************************

// **************************************************
// Solution (3)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//	}

//	private static void CreateCategory()
//	{
//		// **************************************************
//		//var databaseContext = new Models.DatabaseContext();

//		//var category =
//		//	new Models.Category
//		//	{
//		//		Name = "My Category",
//		//	};

//		//databaseContext.Categories.Add(entity: category);

//		//databaseContext.SaveChanges();

//		//databaseContext.Dispose();
//		////databaseContext = null;
//		// **************************************************

//		using (var databaseContext = new Models.DatabaseContext())
//		{
//			var category =
//				new Models.Category
//				{
//					Name = "My Category",
//				};

//			databaseContext.Categories.Add(entity: category);

//			databaseContext.SaveChanges();
//		}
//	}
//}
// **************************************************
// /Solution (3)
// **************************************************

// **************************************************
// Solution (4)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//	}

//	private static void CreateCategory()
//	{
//		// **************************************************
//		//using (var databaseContext = new Models.DatabaseContext())
//		//{
//		//	var category =
//		//		new Models.Category
//		//		{
//		//			Name = "My Category",
//		//		};

//		//	databaseContext.Categories.Add(entity: category);

//		//	databaseContext.SaveChanges();
//		//}
//		// **************************************************

//		using var databaseContext =
//			new Models.DatabaseContext();

//		var category =
//			new Models.Category
//			{
//				Name = "My Category",
//			};

//		databaseContext.Categories.Add(entity: category);

//		databaseContext.SaveChanges();
//	}
//}
// **************************************************
// /Solution (4)
// **************************************************

// **************************************************
// Solution (5)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//	}

//	private static void CreateCategory()
//	{
//		// **************************************************
//		//DisposableClass? disposableObject = null;

//		//try
//		//{
//		//	disposableObject = new();

//		//	// با آن کار می‌کنیم
//		//}
//		//catch (System.Exception ex)
//		//{
//		//	// Log Error!

//		//	// از نظر مسائل ظاهری و امنیتی دستور ذیل مناسب نمی‌باشد
//		//	//System.Console.WriteLine(value: ex.Message);

//		//	System.Console.WriteLine
//		//		(value: "Unexpected Error!");
//		//}
//		//finally
//		//{
//		//	disposableObject?.Dispose();
//		//}
//		// **************************************************

//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new();

//			var category =
//				new Models.Category
//				{
//					Name = "My Category",
//				};

//			databaseContext.Categories.Add(entity: category);

//			databaseContext.SaveChanges();
//		}
//		catch (System.Exception ex)
//		{
//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			//if (databaseContext != null)
//			//{
//			//	databaseContext.Dispose();
//			//	databaseContext = null;
//			//}

//			//if (databaseContext != null)
//			//{
//			//	databaseContext.Dispose();
//			//	//databaseContext = null;
//			//}

//			//if (databaseContext is not null)
//			//{
//			//	databaseContext.Dispose();
//			//}

//			databaseContext?.Dispose();
//		}
//	}
//}
// **************************************************
// /Solution (5)
// **************************************************

// **************************************************
// Solution (6)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main()
//	{
//		CreateCategory();
//	}

//	private static void CreateCategory()
//	{
//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new();

//			var category =
//				new Models.Category
//				{
//					Name = "My Category",
//				};

//			// **************************************************
//			var id =
//				category.Id;

//			// خطا می‌دهد EF Core در
//			// مشکلی نداشت و صرفا توجهی به مقدار ما نمی‌کرد EF ولی در

//			// Cannot insert explicit value for identity column
//			// in table 'Categories' when IDENTITY_INSERT is set to OFF.

//			//category.Id = 12345;
//			//category.Id = 12_345;
//			// **************************************************

//			// **************************************************
//			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entityEntry;

//			entityEntry =
//				databaseContext.Entry(entity: category);
//			// **************************************************

//			// **************************************************
//			// **************************************************
//			// **************************************************
//			//databaseContext.Categories.Add(entity: category);

//			// Type: Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry
//			//entityEntry =
//			//	databaseContext.Categories.Add(entity: category);
//			// **************************************************

//			// **************************************************
//			// New in EF Core
//			//databaseContext.Add(entity: category);

//			// New in EF Core
//			// Type: Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry
//			entityEntry =
//				databaseContext.Add(entity: category);
//			// **************************************************
//			// **************************************************
//			// **************************************************

//			switch (entityEntry.State)
//			{
//				case Microsoft.EntityFrameworkCore.EntityState.Detached:
//				{
//					break;
//				}

//				case Microsoft.EntityFrameworkCore.EntityState.Added:
//				{
//					break;
//				}

//				case Microsoft.EntityFrameworkCore.EntityState.Unchanged:
//				{
//					break;
//				}

//				case Microsoft.EntityFrameworkCore.EntityState.Modified:
//				{
//					break;
//				}

//				case Microsoft.EntityFrameworkCore.EntityState.Deleted:
//				{
//					break;
//				}
//			}

//			// **************************************************
//			//databaseContext.SaveChanges();

//			var affectedRows =
//				databaseContext.SaveChanges();

//			// بعد از عملیات ذخیره‌سازی، مقدار
//			// آی دی از بانک اطلاعاتی دریافت می‌شود
//			id = category.Id;
//			// **************************************************
//		}
//		catch (System.Exception ex)
//		{
//			//ex.InnerException.Message

//			// Cannot insert explicit value for identity column
//			// in table 'Categories' when IDENTITY_INSERT is set
//			// to OFF.

//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			databaseContext?.Dispose();
//		}
//	}
//}
// **************************************************
// /Solution (6)
// **************************************************

// **************************************************
// Solution (7)
// **************************************************
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	// Note: 'MainAsync' does not work!
//	//public static async System.Threading.Tasks.Task MainAsync()
//	public static async System.Threading.Tasks.Task Main()
//	{
//		await CreateCategoryAsync();
//	}

//	//private static void SomeFunction1()
//	//{
//	//}

//	//private static async System.Threading.Tasks.Task SomeFunction1Async()
//	//{
//	//}

//	//private static int SomeFunction2()
//	//{
//	//}

//	//private static async System.Threading.Tasks.Task<int> SomeFunction2Async()
//	//{
//	//}

//	private static async System.Threading.Tasks.Task CreateCategoryAsync()
//	{
//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new();

//			var category =
//				new Models.Category
//				{
//					Name = "My Category",
//				};

//			//var entityEntry =
//			//	databaseContext.Add(entity: category);

//			var entityEntry =
//				await
//				databaseContext.AddAsync(entity: category);

//			//var affectedRows =
//			//	databaseContext.SaveChanges();

//			var affectedRows =
//				await
//				databaseContext.SaveChangesAsync();

//			//System.Console.WriteLine
//			//	(value: $"affectedRows: {affectedRows}");

//			// اگر سوتی دادم
//			//System.Console.WriteLine
//			//	(value: $"afectedRows: {affectedRows}");

//			System.Console.WriteLine
//				(value: $"{nameof(affectedRows)}: {affectedRows}");

//			// اگر سوتی دادم
//			//System.Console.WriteLine
//			//	(value: $"{nameof(afectedRows)}: {affectedRows}");
//		}
//		catch (System.Exception ex)
//		{
//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			if (databaseContext is not null)
//			{
//				//databaseContext.Dispose();
//				await databaseContext.DisposeAsync();
//			}
//		}
//	}
//}
// **************************************************
// /Solution (7)
// **************************************************

// **************************************************
// Solution (8)
// **************************************************
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	public static async System.Threading.Tasks.Task Main()
//	{
//		await CreateCategoryAsync();
//		await DisplayCategoriesAsync();
//	}

//	private static async System.Threading.Tasks.Task CreateCategoryAsync()
//	{
//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new();

//			var category =
//				new Models.Category
//				{
//					Name = "My Category",
//				};

//			var entityEntry =
//				await
//				databaseContext.AddAsync(entity: category);

//			var affectedRows =
//				await
//				databaseContext.SaveChangesAsync();
//		}
//		catch (System.Exception ex)
//		{
//			// Log Error!

//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			if (databaseContext is not null)
//			{
//				await databaseContext.DisposeAsync();
//			}
//		}
//	}

//	private static async System.Threading.Tasks.Task DisplayCategoriesAsync()
//	{
//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new();

//			// **************************************************
//			// **************************************************
//			// **************************************************
//			//var categories =
//			//	databaseContext.Categories.ToList();
//			// **************************************************

//			// **************************************************
//			//var categories =
//			//	databaseContext.Categories
//			//	// ToList() -> using System.Linq;
//			//	.ToList()
//			//	;
//			// **************************************************

//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	// New in EF Core
//			//	// ToListAsync() -> using Microsoft.EntityFrameworkCore;
//			//	.ToListAsync()
//			//	;
//			// **************************************************
//			// SELECT * FROM Categories
//			// **************************************************

//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	// Where() -> using System.Linq
//			//	.Where(predicate: current => current.Id <= 100)
//			//	.ToListAsync()
//			//	;
//			// **************************************************
//			// SELECT * FROM Categories WHERE Id <= 100
//			// **************************************************

//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	// OrderBy() -> using System.Linq
//			//	.OrderBy(keySelector: current => current.Name)
//			//	.ToListAsync()
//			//	;
//			// **************************************************
//			// SELECT * FROM Categories ORDER BY Name
//			// OR
//			// SELECT * FROM Categories ORDER BY Name ASC
//			// **************************************************

//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	// OrderByDescending() -> using System.Linq
//			//	.OrderByDescending(keySelector: current => current.Id)
//			//	.ToListAsync()
//			//	;
//			// **************************************************
//			// SELECT * FROM Categories ORDER BY Id DESC
//			// **************************************************

//			// **************************************************
//			// اهمیت داشت، ولی در این نسخه اهمیتی ندارد Where and OrderBy در نسخه قدیم، ترتیب نوشتن
//			// ولی اصولا عادت کنید که به شکل و به ترتیب ذیل بنویسید
//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	.Where(predicate: current => current.Id <= 100)
//			//	.OrderBy(keySelector: current => current.Name)
//			//	.ToListAsync()
//			//	;

//			//foreach (var item in categories)
//			//{
//			//	//var message =
//			//	//	$"Id: {item.Id} - Name: {item.Name}";

//			//	var message =
//			//		$"{nameof(item.Id)}: {item.Id} - {nameof(item.Name)}: {item.Name}";

//			//	System.Console.WriteLine(value: message);
//			//}
//			// **************************************************
//			// SELECT * FROM Categories WHERE Id <= 100 ORDER BY Name
//			// **************************************************
//			// **************************************************
//			// **************************************************

//			// **************************************************
//			string? name = "My Category";
//			// **************************************************

//			// **************************************************
//			// **************************************************
//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	.Where(predicate: current => current.Name == name)
//			//	.ToListAsync()
//			//	;
//			// **************************************************
//			// SELECT * FROM Categories WHERE Name = 'My Category'
//			// **************************************************

//			// **************************************************
//			// کلاسیک کار می‌کند  EF دقت کنید که دستور ذیل در نسخه
//			// ولی در نسخه جدید کار نمی‌کند، لذا در
//			// از آن استفاده نمی‌کنیم EF Core نسخه
//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	.Where(predicate: current => string.Compare(current.Name, name, true) == 0)
//			//	.ToListAsync()
//			//	;
//			// **************************************************

//			// **************************************************
//			// باشد به خطا خواهد خورد null ،name دستور ذیل در شرایطی که
//			// **************************************************
//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	.Where(predicate: current => current.Name.ToLower() == name.ToLower())
//			//	.ToListAsync()
//			//	;

//			//// OR

//			//var categories =
//			//	await
//			//	databaseContext.Categories
//			//	.Where(predicate: current => current.Name.ToUpper() == name.ToUpper())
//			//	.ToListAsync()
//			//	;
//			// **************************************************

//			// **************************************************
//			//if (name is not null)
//			//{
//			//	var categories =
//			//		await
//			//		databaseContext.Categories
//			//		.Where(predicate: current => current.Name.ToLower() == name.ToLower())
//			//		.ToListAsync()
//			//		;
//			//}
//			// **************************************************

//			// **************************************************
//			// دستور درست
//			// **************************************************
//			//if (name is not null)
//			//{
//			//	var categories =
//			//		await
//			//		databaseContext.Categories
//			//		.Where(predicate: current =>
//			//			current.Name != null &&
//			//			current.Name.ToLower() == name.ToLower())
//			//		.ToListAsync()
//			//		;
//			//}
//			// **************************************************
//			// **************************************************
//			// **************************************************

//			// **************************************************
//			//name = "My";

//			//if (name is not null)
//			//{
//			//	var categories =
//			//		await
//			//		databaseContext.Categories
//			//		.Where(predicate: current => current.Name != null &&
//			//			current.Name.ToLower().StartsWith(name.ToLower()))
//			//		.ToListAsync()
//			//		;

//			//	foreach (var item in categories)
//			//	{
//			//		var message =
//			//			$"{nameof(item.Id)}: {item.Id} - {nameof(item.Name)}: {item.Name}";

//			//		System.Console.WriteLine(value: message);
//			//	}
//			//}
//			// **************************************************
//			// SELECT * FROM Categories WHERE Name LIKE 'My%'
//			// **************************************************

//			// **************************************************
//			//name = "Category";

//			//if (name is not null)
//			//{
//			//	var categories =
//			//		await
//			//		databaseContext.Categories
//			//		.Where(predicate: current => current.Name != null &&
//			//			current.Name.ToLower().EndsWith(name.ToLower()))
//			//		.ToListAsync()
//			//		;

//			//	foreach (var item in categories)
//			//	{
//			//		var message =
//			//			$"{nameof(item.Id)}: {item.Id} - {nameof(item.Name)}: {item.Name}";

//			//		System.Console.WriteLine(value: message);
//			//	}
//			//}
//			// **************************************************
//			// SELECT * FROM Categories WHERE Name LIKE '%Category'
//			// **************************************************

//			// **************************************************
//			//name = "Gory";

//			//if (name is not null)
//			//{
//			//	var categories =
//			//		await
//			//		databaseContext.Categories
//			//		.Where(predicate: current => current.Name != null &&
//			//			current.Name.ToLower().Contains(name.ToLower()))
//			//		.ToListAsync()
//			//		;

//			//	foreach (var item in categories)
//			//	{
//			//		var message =
//			//			$"{nameof(item.Id)}: {item.Id} - {nameof(item.Name)}: {item.Name}";

//			//		System.Console.WriteLine(value: message);
//			//	}
//			//}
//			// **************************************************
//			// SELECT * FROM Categories WHERE Name LIKE '%Gory%'
//			// **************************************************
//		}
//		catch (System.Exception ex)
//		{
//			// Log Error!

//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			if (databaseContext is not null)
//			{
//				await databaseContext.DisposeAsync();
//			}
//		}
//	}
//}
// **************************************************
// /Solution (8)
// **************************************************

// **************************************************
// Solution (9)
// **************************************************
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application;

internal static class Program : object
{
	static Program()
	{
	}

	public static async System.Threading.Tasks.Task Main()
	{
		await CreateCategoryAsync();
		await DisplayCategoriesAsync();

		// New
		await UpdateTheFirstCategoryAsync();
		await DisplayCategoriesAsync();

		// New
		await UpdateSomeCategoriesAsync();
		await DisplayCategoriesAsync();

		// New
		await DeleteTheFirstCategoryAsync();
		await DisplayCategoriesAsync();

		// New
		await DeleteSomeCategoriesAsync();
		await DisplayCategoriesAsync();
	}

	private static async System.Threading.Tasks.Task CreateCategoryAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Models.DatabaseContext();

			var category =
				new Models.Category
				{
					Name = "My Category",
				};

			// **************************************************
			// **************************************************
			// **************************************************
			//databaseContext.Categories.Add(entity: category);

			//await databaseContext.Categories.AddAsync(entity: category);
			// **************************************************

			// **************************************************
			//var entityEntry =
			//	databaseContext.Categories.Add(entity: category);

			//var entityEntry =
			//	await
			//	databaseContext.Categories.AddAsync(entity: category);
			// **************************************************

			// **************************************************
			// تابع ذیل خروجی ندارد
			//databaseContext.Categories.AddRange(entities: category);

			// تابع ذیل خروجی ندارد
			//await databaseContext.Categories.AddRangeAsync(entities: category);
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//databaseContext.Add(entity: category);

			//await databaseContext.AddAsync(entity: category);
			// **************************************************

			// **************************************************
			//var entityEntry =
			//	databaseContext.Add(entity: category);

			// نسبت به شش حالتی که وجود دارد
			// به شخصه، این حالت را بیشتر می‌پسندم
			var entityEntry =
				await
				databaseContext.AddAsync(entity: category);
			// **************************************************

			// **************************************************
			// تابع ذیل خروجی ندارد
			//databaseContext.AddRange(entities: category);

			// تابع ذیل خروجی ندارد
			//await databaseContext.AddRangeAsync(entities: category);
			// **************************************************
			// **************************************************
			// **************************************************

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext is not null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	private static async System.Threading.Tasks.Task DisplayCategoriesAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new();

			var categories =
				await
				databaseContext.Categories
				.Where(predicate: current => current.Id <= 100)
				.OrderBy(keySelector: current => current.Name)
				.ToListAsync()
				;

			foreach (var item in categories)
			{
				var message =
					$"{nameof(item.Id)}: {item.Id} - {nameof(item.Name)}: {item.Name}";

				System.Console.WriteLine(value: message);
			}
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext != null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// New
	/// </summary>
	private static async System.Threading.Tasks.Task UpdateTheFirstCategoryAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new();

			// برمی‌گرداند null ،اگر پیدا نکند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، اولین آن‌را برمی‌گرداند
			//var category =
			//	databaseContext.Categories
			//	// FirstOrDefault() -> using System.Linq;
			//	.FirstOrDefault();

			// New in EF Core
			//var category =
			//	await
			//	databaseContext.Categories
			//	// FirstOrDefaultAsync() -> using Microsoft.EntityFrameworkCore;
			//	.FirstOrDefaultAsync();

			// خیلی توصیه نمی‌کنم
			//var category =
			//	await
			//	databaseContext.Categories
			//	.FirstOrDefaultAsync(predicate: current => current.Id <= 100);

			//var category =
			//await
			//databaseContext.Categories
			//.Where(predicate: current => current.Id <= 100)
			//.FirstOrDefaultAsync();

			var category =
				await
				databaseContext.Categories
				.Where(predicate: current => current.Id <= 100)
				.OrderBy(keySelector: current => current.Name)
				.FirstOrDefaultAsync();

			if (category is null)
			{
				System.Console.WriteLine
					(value: "There is not any category!");

				return;
			}

			//category.Name = "Googooli";

			category.Name =
				$"{category.Name}_{category.Id}";

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();

			// **************************************************
			// اگر پیدا نکند، خطا تولید می‌کند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، اولین آن‌را برمی‌گرداند
			//var theCategory =
			//	databaseContext.Categories
			//	.First();

			// New in EF Core
			//var theCategory =
			//	await
			//	databaseContext.Categories
			//	.FirstAsync();
			// **************************************************

			// **************************************************
			// برمی‌گرداند null ،اگر پیدا نکند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، آخرین آن‌را برمی‌گرداند
			//var theCategory =
			//	databaseContext.Categories
			//	.LastOrDefault();

			// New in EF Core
			//var theCategory =
			//	await
			//	databaseContext.Categories
			//	.LastOrDefaultAsync();
			// **************************************************

			// **************************************************
			// اگر پیدا نکند، خطا تولید می‌کند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، آخرین آن‌را برمی‌گرداند
			//var theCategory =
			//	databaseContext.Categories
			//	.Last();

			// New in EF Core
			//var theCategory =
			//	await
			//	databaseContext.Categories
			//	.LastAsync();
			// **************************************************

			// **************************************************
			// برمی‌گرداند null ،اگر پیدا نکند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، خطا تولید می‌کند
			//var theCategory =
			//	databaseContext.Categories
			//	.SingleOrDefault();

			// New in EF Core
			//var theCategory =
			//	await
			//	databaseContext.Categories
			//	.SingleOrDefaultAsync();
			// **************************************************

			// **************************************************
			// اگر پیدا نکند، خطا تولید می‌کند
			// اگر فقط یکی پیدا کند، همان یکی را برمی‌گرداند
			// اگر بیش از یکی پیدا کند، خطا تولید می‌کند
			//var theCategory =
			//	databaseContext.Categories
			//	.Single();

			// New in EF Core
			//var theCategory =
			//	await
			//	databaseContext.Categories
			//	.SingleAsync();
			// **************************************************
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext != null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// New
	/// </summary>
	private static async System.Threading.Tasks.Task UpdateSomeCategoriesAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Models.DatabaseContext();

			var categories =
				await
				databaseContext.Categories
				.Where(predicate: current => current.Id <= 100)
				.OrderBy(keySelector: current => current.Name)
				.ToListAsync()
				;

			foreach (var item in categories)
			{
				//item.Name = "Googooli";

				item.Name =
					$"{item.Name}_{item.Id}";

				//var affectedRows =
				//	await
				//	databaseContext.SaveChangesAsync();
			}

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext != null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// New
	/// </summary>
	private static async System.Threading.Tasks.Task DeleteTheFirstCategoryAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Models.DatabaseContext();

			var category =
				await
				databaseContext.Categories
				.Where(predicate: current => current.Id <= 100)
				.OrderBy(keySelector: current => current.Name)
				.FirstOrDefaultAsync();

			if (category == null)
			{
				System.Console.WriteLine
					(value: "There is not any category!");

				return;
			}

			// **************************************************
			//databaseContext.Categories.Remove(entity: category);

			//var entityEntry =
			//	databaseContext.Categories.Remove(entity: category);

			// دقت کنید که تابع ذیل، خروجی ندارد
			//databaseContext.Categories.RemoveRange(entities: category);
			// **************************************************

			// **************************************************
			// New in .NET Core
			//databaseContext.Remove(entity: category);

			// New in .NET Core
			var entityEntry =
				databaseContext.Remove(entity: category);

			// New in .NET Core
			// دقت کنید که تابع ذیل، خروجی ندارد
			//databaseContext.RemoveRange(entities: category);
			// **************************************************

			// **************************************************
			// ندارند Async دقت کنید که توابع فوق
			// **************************************************

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext != null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// New
	/// </summary>
	private static async System.Threading.Tasks.Task DeleteSomeCategoriesAsync()
	{
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Models.DatabaseContext();

			var categories =
				await
				databaseContext.Categories
				.Where(predicate: current => current.Id <= 100)
				.OrderBy(keySelector: current => current.Name)
				.ToListAsync()
				;

			// **************************************************
			// **************************************************
			// **************************************************
			//foreach (var item in categories)
			//{
			//	databaseContext.Remove(entity: item);

			//	//var affectedRows =
			//	//	await
			//	//	databaseContext.SaveChangesAsync();
			//}
			// **************************************************

			// OR

			// **************************************************
			//databaseContext.Categories.RemoveRange(entities: categories);
			// **************************************************

			// OR

			// **************************************************
			// نسبت به سه حالتی که وجود دارد
			// به شخصه، این حالت را بیشتر می‌پسندم
			databaseContext.RemoveRange(entities: categories);
			// **************************************************
			// **************************************************
			// **************************************************

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			// Log Error!

			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			if (databaseContext != null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}
}
// **************************************************
// /Solution (9)
// **************************************************

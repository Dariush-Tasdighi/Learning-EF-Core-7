//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//// **************************************************
//try
//{
//	using var applicationDbContext = new ApplicationDbContext();

//	var category =
//		applicationDbContext.Categories
//		.FirstOrDefault();

//	//if (category == null)
//	if (category is null)
//	{
//		Console.WriteLine
//			(value: "There is not any category!");
//	}
//	else
//	{
//		Console.WriteLine(value: category.ToString());
//	}
//}
//catch (Exception ex)
//{
//	Console.WriteLine(value: ex.Message);
//}
//// **************************************************

//// **************************************************
////try
////{
////	using var applicationDbContext = new ApplicationDbContext();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.FirstOrDefault(x => x.Id == 1);

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(x => x.Id == 1)
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(cagetory => cagetory.Id == 1)
////	//	.FirstOrDefault();

////	var category =
////		applicationDbContext.Categories
////		.Where(current => current.Id == 1)
////		.FirstOrDefault();

////	if (category is null)
////	{
////		Console.WriteLine
////			(value: "There is not any category!");
////	}
////	else
////	{
////		Console.WriteLine(value: category.ToString());
////	}
////}
////catch (Exception ex)
////{
////	Console.WriteLine(value: ex.Message);
////}
//// **************************************************

//// **************************************************
////try
////{
////	using var applicationDbContext = new ApplicationDbContext();

////	var category =
////		applicationDbContext.Categories
////		.Where(current => current.Name == "My Category 1")
////		.FirstOrDefault();
////		//.ToList(); // بعدا آموزش داده می‌شود

////	// کار می‌کرد EF دستور ذیل در
////	// کار نمی‌کند EF Core ولی متاسفانه، در
////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => string.Compare(current.Name, "My Category 1", true) == 0)
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name.ToLower() == "My Category 1".ToLower()) // OR ToUppoer()
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name != null
////	//		&& current.Name.ToLower() == "My Category 1".ToLower())
////	//	.FirstOrDefault();

////	// Note: متاسفانه دستور ذیل کار نمی‌کند
////	// StartsWith(value: "My") -> value:
////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name != null
////	//		&& current.Name.ToLower().StartsWith(value: "My"))
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name != null
////	//		&& current.Name.ToLower().StartsWith("My"))
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name != null
////	//		&& current.Name.ToLower().EndsWith("Category 1"))
////	//	.FirstOrDefault();

////	//var category =
////	//	applicationDbContext.Categories
////	//	.Where(current => current.Name != null
////	//		&& current.Name.ToLower().Contains("Category"))
////	//	.FirstOrDefault();

////	if (category is null)
////	{
////		Console.WriteLine
////			(value: "There is not any category!");
////	}
////	else
////	{
////		Console.WriteLine(value: category.ToString());
////	}
////}
////catch (Exception ex)
////{
////	Console.WriteLine(value: ex.Message);
////}
//// **************************************************

//public class Category : object
//{
//	public Category() : base()
//	{
//	}

//	public int Id { get; set; }

//	public string? Name { get; set; }

//	/// <summary>
//	/// New
//	/// </summary>
//	public override string ToString()
//	{
//		//var result =
//		//	$"Id: {Id} - Name: {Name}";

//		var result =
//			$"{nameof(Id)}: {Id} - {nameof(Name)}: {Name}";

//		return result;
//	}
//}

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<Category> Categories { get; set; }

//	protected override void OnConfiguring
//		(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		optionsBuilder.UseSqlServer
//			(connectionString: connectionString);
//	}
//}

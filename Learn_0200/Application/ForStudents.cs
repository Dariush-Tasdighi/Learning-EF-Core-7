// **************************************************
// <Project Sdk="Microsoft.NET.Sdk">

// 	<PropertyGroup>
// 		<Nullable>enable</Nullable>
// 		<OutputType>Exe</OutputType>
// 		<TargetFramework>net7.0</TargetFramework>
// 		<!--<ImplicitUsings>enable</ImplicitUsings>-->
// 	</PropertyGroup>

// 	<ItemGroup>
// 		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.11" />
// 	</ItemGroup>

// </Project>
// **************************************************

// **************************************************
//namespace Models;

///// <summary>
///// کلاس طبقه‌بندی
///// </summary>
//public class Category : object
//{
//	#region Constructor
//	/// <summary>
//	/// سازنده پیش‌فرض کلاس
//	/// </summary>
//	public Category() : base()
//	{
//	}
//	#endregion /Constructor

//	#region Properties

//	#region public int Id { get; set; }
//	/// <summary>
//	/// شناسه
//	/// </summary>
//	public int Id { get; set; }
//	#endregion /public int Id { get; set; }

//	#region public string? Name { get; set; }
//	/// <summary>
//	/// نام
//	/// </summary>
//	public string? Name { get; set; }
//	#endregion /public string? Name { get; set; }

//	#endregion /Properties
//}
// **************************************************

// **************************************************
//using Microsoft.EntityFrameworkCore;

//namespace Models;

//public class DatabaseContext :
//	Microsoft.EntityFrameworkCore.DbContext
//{
//	public DatabaseContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }

//	protected override void OnConfiguring
//		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		optionsBuilder.UseSqlServer
//			(connectionString: connectionString);
//	}
//}
// **************************************************

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
//		Models.DatabaseContext databaseContext = new Models.DatabaseContext();

//		Models.Category category = new Models.Category();

//		category.Name = "My Category";

//		databaseContext.Categories.Add(entity: category);

//		databaseContext.SaveChanges();
//	}
//}
// **************************************************

// **************************************************
//namespace Application.Models -> namespace Models
//
// Best Practice:
//
// Dtos
// Models
// Domain
// ViewModels
// Infrastructure
// **************************************************

// **************************************************
//namespace Models;

//public class Category
//{
//	/// <summary>
//	/// Primary Key -> Unique (منحصر به فرد)
//	/// </summary>
//	public int Id { get; set; }

//	public string Name { get; set; }
//}
// **************************************************

// **************************************************
// قانون مهم
// هر آن‌چه ننویسیم، کامپایلر آن‌را می‌نویسید
// و یا برداشت می‌کند را به صراحت می‌نویسیم
// **************************************************
//namespace Models;

//public class Category : object
//{
//	public Category() : base()
//	{
//	}

//	public int Id { get; set; }

//	public string Name { get; set; }
//}
// **************************************************

// **************************************************
// *** Read: Documents -> Readme.txt ****************
// **************************************************

// **************************************************
// Adding XML Documentation
// **************************************************
//namespace Models;

///// <summary>
///// کلاس طبقه‌بندی
///// </summary>
//public class Category : object
//{
//	/// <summary>
//	/// سازنده پیش‌فرض کلاس
//	/// </summary>
//	public Category() : base()
//	{
//	}

//	/// <summary>
//	/// شناسه
//	/// </summary>
//	public int Id { get; set; }

//	/// <summary>
//	/// نام
//	/// </summary>
//	public string Name { get; set; }
//}
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

//	#region public int Id { get; set; }
//	/// <summary>
//	/// شناسه
//	/// </summary>
//	public int Id { get; set; }
//	#endregion /public int Id { get; set; }

//	#region public string Name { get; set; }
//	/// <summary>
//	/// نام
//	/// </summary>
//	public string Name { get; set; }
//	#endregion /public string Name { get; set; }
//}
// **************************************************

// **************************************************
// Learning Nullable
// **************************************************
//namespace Models;

///// <summary>
///// کلاس طبقه‌بندی
///// </summary>
//public class Category : object
//{
//	//#region Constructor
//	///// <summary>
//	///// سازنده پیش‌فرض کلاس
//	///// </summary>
//	//public Category() : base()
//	//{
//	//}
//	//#endregion /Constructor

//	#region Constructor
//	/// <summary>
//	/// سازنده کلاس
//	/// </summary>
//	/// <param name="name">نام</param>
//	public Category(string name) : base()
//	{
//		Name = name;
//	}
//	#endregion /Constructor

//	#region public int Id { get; set; }
//	/// <summary>
//	/// شناسه
//	/// </summary>
//	public int Id { get; set; }
//	#endregion /public int Id { get; set; }

//	#region public string Name { get; set; }
//	/// <summary>
//	/// نام
//	/// </summary>
//	public string Name { get; set; }
//	#endregion /public string Name { get; set; }
//}
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
//		Name = string.Empty;
//		//Name = ""; // Null String
//	}
//	#endregion /Constructor

//	#region public int Id { get; set; }
//	/// <summary>
//	/// شناسه
//	/// </summary>
//	public int Id { get; set; }
//	#endregion /public int Id { get; set; }

//	#region public string Name { get; set; }
//	/// <summary>
//	/// نام
//	/// </summary>
//	public string Name { get; set; }
//	#endregion /public string Name { get; set; }
//}
// **************************************************

// **************************************************
namespace Models;

/// <summary>
/// کلاس طبقه‌بندی
/// </summary>
public class Category : object
{
	#region Constructor
	/// <summary>
	/// سازنده پیش‌فرض کلاس
	/// </summary>
	public Category() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region public int Id { get; set; }
	/// <summary>
	/// شناسه
	/// </summary>
	public int Id { get; set; }
	#endregion /public int Id { get; set; }

	#region public string? Name { get; set; }
	/// <summary>
	/// نام
	/// </summary>
	public string? Name { get; set; }
	#endregion /public string? Name { get; set; }

	#endregion /Properties
}
// **************************************************

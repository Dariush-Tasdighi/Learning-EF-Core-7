///// <summary>
///// POCO -> Plain Old CLR Objects
///// </summary>
//public class Category : Base.Entity, IHasIsActive
//{
//}

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

	#region int Id
	/// <summary>
	/// شناسه
	/// </summary>
	public int Id { get; set; }

	//public long Id { get; set; }

	//public System.Guid Id { get; set; }
	#endregion /int Id

	#region string? Name
	/// <summary>
	/// نام
	/// </summary>
	public string? Name { get; set; }
	#endregion /string? Name

	#endregion Properties
}

// **************************************************
//namespace Models
//{
//	public class Person
//	{
//		public int Age { get; set; }

//		public string FullName { get; set; }

//		public void ShowInformation()
//		{
//			//var message = "I'm " + FullName + " and " + Age + " years old.";

//			// Breaking Line
//			//var message =
//			//	"I'm " + FullName + " and " +  Age + " years old.";

//			// Using string.Format()
//			//var message =
//			//	string.Format("I'm {0} and {1} years old.", FullName, Age);

//			// Using Input Parameter Names
//			//var message =
//			//	string.Format(format: "I'm {0} and {1} years old.", FullName, Age);

//			// Using $ String
//			var message =
//				$"I'm {FullName} and {Age} years old.";

//			System.Console.WriteLine(value: message);
//		}
//	}
//}
// **************************************************

// **************************************************
//// New - namespace; instead of namespace{}
//namespace Models;

//// New - object (Not System.Object)
//public class Person : object
//{
//	// New - Default Constructor
//	public Person() : base()
//	{
//	}

//	public int Age { get; set; }

//	// New - Using string? instead of string
//	public string? FullName { get; set; }

//	public void ShowInformation()
//	{
//		var message =
//			$"I'm {FullName} and {Age} years old.";

//		System.Console.WriteLine(value: message);
//	}
//}
// **************************************************

// **************************************************
// *** Using region and endregion *******************
// **************************************************
//namespace Models;

//public class Person : object
//{
//	#region Constructor
//	public Person() : base()
//	{
//	}
//	#endregion /Constructor

//	#region public int Age { get; set; }
//	public int Age { get; set; }
//	#endregion /public int Age { get; set; }

//	#region public string? FullName { get; set; }
//	public string? FullName { get; set; }
//	#endregion /public string? FullName { get; set; }

//	#region ShowInformation()
//	public void ShowInformation()
//	{
//		var message =
//			$"I'm {FullName} and {Age} years old.";

//		System.Console.WriteLine(value: message);
//	}
//	#endregion /ShowInformation()
//}
// **************************************************

// **************************************************
// *** XML Documentation ****************************
// **************************************************
//namespace Models;

///// <summary>
///// کلاس شخص
///// </summary>
//public class Person : object
//{
//	#region Constructor
//	/// <summary>
//	/// سازنده
//	/// </summary>
//	public Person() : base()
//	{
//	}
//	#endregion /Constructor

//	#region public int Age { get; set; }
//	/// <summary>
//	/// سن
//	/// </summary>
//	public int Age { get; set; }
//	#endregion /public int Age { get; set; }

//	#region public string? FullName { get; set; }
//	/// <summary>
//	/// نام و نام خانوادگی
//	/// </summary>
//	public string? FullName { get; set; }
//	#endregion /public string? FullName { get; set; }

//	#region ShowInformation()
//	/// <summary>
//	/// توسط این تابع اطلاعات شخص نمایش داده می‌شود
//	/// </summary>
//	public void ShowInformation()
//	{
//		var message =
//			$"I'm {FullName} and {Age} years old.";

//		System.Console.WriteLine(value: message);
//	}
//	#endregion /ShowInformation()
//}
// **************************************************

// **************************************************
// *** Using region and endregion - سختگیرانه *******
// **************************************************
namespace Models;

/// <summary>
/// کلاس شخص
/// </summary>
public class Person : object
{
	#region Constructor
	/// <summary>
	/// سازنده
	/// </summary>
	public Person() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region public int Age { get; set; }
	/// <summary>
	/// سن
	/// </summary>
	public int Age { get; set; }
	#endregion /public int Age { get; set; }

	#region public string? FullName { get; set; }
	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	public string? FullName { get; set; }
	#endregion /public string? FullName { get; set; }

	#endregion /Properties

	#region Methods

	#region ShowInformation()
	/// <summary>
	/// توسط این تابع اطلاعات شخص نمایش داده می‌شود
	/// </summary>
	public void ShowInformation()
	{
		var message =
			$"I'm {FullName} and {Age} years old.";

		System.Console.WriteLine(value: message);
	}
	#endregion /ShowInformation()

	#endregion /Methods
}
// **************************************************

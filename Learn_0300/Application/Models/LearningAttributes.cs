using Dtat;

namespace Models;

// **************************************************
// *** Category 01 **********************************
// **************************************************
/// <summary>
/// POCO -> Plain Old CLR Objects
/// </summary>
public class Category01 : object
{
	public Category01() : base()
	{
	}

	// **********
	public int Id { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 02 **********************************
// **************************************************
public class Category02 : object
{
	public Category02() : base()
	{
	}

	// **********
	public int ID { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 03 **********************************
// **************************************************
public class Category03 : object
{
	public Category03() : base()
	{
	}

	// **********
	public int Category03Id { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 04 **********************************
// **************************************************
public class Category04 : object
{
	public Category04() : base()
	{
	}

	// **********
	public int Category04ID { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 05 **********************************
// **************************************************
public class Category05 : object
{
	public Category05() : base()
	{
	}

	// **********
	/// <summary>
	/// خطا می‌دهد
	/// </summary>
	public int Key { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 06 **********************************
// **************************************************
public class Category06 : object
{
	public Category06() : base()
	{
	}

	// **********
	/// <summary>
	/// این ویژگی فقط مربوط به بانک‌اطلاعاتی می‌شود
	/// 
	/// داریم Key چون در اسکیوال کلمه
	/// می‌شود [Key] تبدیل به
	/// </summary>
	[System.ComponentModel.DataAnnotations.Key]
	public int Key { get; set; }
	// **********

	// **********
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 07 **********************************
// **************************************************
public class Category07 : object
{
	public Category07() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// این ویژگی هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 100)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 08 **********************************
// **************************************************
public class Category08 : object
{
	public Category08() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// این ویژگی فقط مربوط به برنامه می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.MinLength
		(length: 3)]

	/// <summary>
	/// این ویژگی هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 100)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 09 **********************************
// **************************************************
public class Category09 : object
{
	public Category09() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// این ویژگی هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 10 **********************************
// **************************************************
public class Category10 : object
{
	public Category10() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// بخشی از این ویژگی، هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// 
	/// و بخشی از آن، صرفا مربوط به برنامه می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 11 **********************************
// **************************************************
public class Category11 : object
{
	public Category11() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// این ویژگی هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 12 **********************************
// **************************************************
public class Category12 : object
{
	public Category12() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	/// <summary>
	/// بخشی از این ویژگی، هم مربوط به برنامه می‌شود
	/// و هم مربوط به بانک اطلاعاتی می‌شود
	/// 
	/// و بخشی از آن، صرفا مربوط به برنامه می‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string? Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 13 **********************************
// **************************************************
// See:
// CreateCategory13Async() Function
// and
// DisplayCategories13Async() Function
// **************************************************
/// <summary>
/// طراحی هوشمندانه که در نسخه قبل امکان‌پذیر نبود
/// </summary>
public class Category13 : object
{
	/// <summary>
	/// را می‌نوشتیم Default Constructor در نسخه قدیم باید حتما
	/// </summary>
	//public Category13() : base()
	//{
	//}

	public Category13(string name) : base()
	{
		Name = name;
	}

	// **********
	/// <summary>
	/// Note: private set;
	/// </summary>
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Note: string? -> string
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 14 **********************************
// **************************************************
public class Category14 : object
{
	public Category14(string name) : base()
	{
		Name = name;

		Ordering = 10_000;
		//Ordering = 10000;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********

	// **********
	/// <summary>
	/// این ویژگی، فقط مربوط به برنامه می‌شود
	/// 
	/// ها Validator
	/// به شرطی عمل می‌کنند که فیلد مربوط به آن
	/// نباشد null
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Range
	//	(minimum: 1, maximum: 100000)]
	[System.ComponentModel.DataAnnotations.Range
		(minimum: 1, maximum: 100_000)]
	public int Ordering { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 15 **********************************
// **************************************************
/// <summary>
/// In Classic EF: Automatically: Country -> Countries Based on Model Name
/// In EF Core: Automatically: Country -> Countries Based on DbSet Property Name
/// </summary>
public class Category15 : object
{
	public Category15(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 10)]

	/// <summary>
	/// این ویژگی فقط مربوط به برنامه می‌شود
	/// </summary>

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: "^\\d$")]

	//[System.ComponentModel.DataAnnotations.RegularExpression
	//	(pattern: "^\\d{10}$")]

	//[System.ComponentModel.DataAnnotations.RegularExpression
	//	(pattern: "^\\d{10,12}$")]
	public string? PostalCode { get; set; }
	// **********

	public bool ValidatePostalCode()
	{
		if (string.IsNullOrEmpty(value: PostalCode))
		{
			return true;
		}

		var result =
			System.Text.RegularExpressions.Regex
			.IsMatch(input: PostalCode, pattern: "^\\d{10}$");

		return result;
	}
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 16 **********************************
// **************************************************
[System.ComponentModel.DataAnnotations.Schema.Table
	(name: "CategoriesTable")]
public class Category16 : object
{
	public Category16(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.Column
		(name: "CategoryId")]
	public int Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]

	[System.ComponentModel.DataAnnotations.Schema.Column
		(name: "CategoryName")]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 17 **********************************
// **************************************************
[System.ComponentModel.DataAnnotations.Schema.Table
	(name: "TABLE_001")]
public class Category17 : object
{
	public Category17(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.Column
		(name: "FIELD_001")]
	public int Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]

	[System.ComponentModel.DataAnnotations.Schema.Column
		(name: "FIELD_002")]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 18 **********************************
// **************************************************
/// <summary>
/// Multiple Schema does not work in Sqlite!
/// Schema does not work in SQL Server Compact Edition at all!
/// </summary>
[System.ComponentModel.DataAnnotations.Schema.Table
	(name: "Categories", Schema = "Cms")]
public class Category18 : object
{
	public Category18(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 19 **********************************
// **************************************************
/// <summary>
/// متاسفانه هیچ‌یک از سه دستور ذیل کار نمی‌کند
/// </summary>

//[System.ComponentModel.DataAnnotations.Schema.Table
//	(Schema = "Cms")]

//[System.ComponentModel.DataAnnotations.Schema.Table
//	(name: null, Schema = "Cms")]

//[System.ComponentModel.DataAnnotations.Schema.Table
//	(name: "", Schema = "Cms")]
public class Category19 : object
{
	public Category19(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]
	public int Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 20 **********************************
// **************************************************
/// <summary>
/// Id:
/// 
///		In C#			In SQL Server Database
/// 
///		int				int
///		long			bigint
///		System.Guid		uniqueidentifier
/// </summary>
public class Category20 : object
{
	public Category20(string name) : base()
	{
		Name = name;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	//[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
	//	(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public int Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 21 **********************************
// **************************************************
// See:
// CreateCategory21Async() Function
// **************************************************
public class Category21 : object
{
	public Category21(string name) : base()
	{
		Name = name;
	}

	// **********
	/// <summary>
	/// بانک اطلاعاتی مقدار آن را
	/// تولید می‌کند و به سمت برنامه ارسال می‌کند
	/// </summary>
	[System.ComponentModel.DataAnnotations.Key]
	public System.Guid Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 22 **********************************
// **************************************************
public class Category22 : object
{
	public Category22(string name) : base()
	{
		Name = name;

		// دستور ذیل صحیح نمی‌باشد
		//Id = new System.Guid();

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 23 **********************************
// **************************************************
// See:
// CreateCategory23Async() Function
// **************************************************
public class Category23 : object
{
	public Category23(string name) : base()
	{
		Name = name;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Note: private set;
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Code { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 24 **********************************
// **************************************************
public class Category24 : object
{
	public Category24(string name) : base()
	{
		Name = name;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Code1 { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Error!
	/// only one column per table can be configured as 'Identity'.
	///
	/// تعریف نمایید Sequence بعدا یاد خواهید گرفت که چیزی به نام
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
	//	(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	//public int Code2 { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 25 **********************************
// **************************************************
// See:
// CreateCategory25Async() Function
// **************************************************
public class Category25 : object
{
	public Category25(string name) : base()
	{
		Name = name;

		//InsertDateTime =
		//	System.DateTime.Now;

		InsertDateTime =
			Dtat.DateTime.Now;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Note: private set;
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Code { get; private set; }
	// **********

	// **********
	// **********
	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100, MinimumLength = 3)]
	public string Name { get; set; }
	// **********

	// **********
	public string DisplayName
	{
		get
		{
			var result =
				$"{Code} - {Name}";

			return result;
		}
	}
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	//public System.DateTime InsertDateTime { get; private set; }

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset InsertDateTime { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Set ای که Property
	/// نداشته باشد تبدیل به فیلد در بانک اطلاعاتی نمی‌شود
	/// </summary>
	public Dtat.PersianDate InsertPersianDate
	{
		get
		{
			var result =
				InsertDateTime.ToPersianDate();

			return result;
		}
	}
	// **********

	// **********
	public Dtat.PersianDateTime InsertPersianDateTime
	{
		get
		{
			var result =
				InsertDateTime.ToPersianDateTime();

			return result;
		}
	}
	// **********
	// **********
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 26 **********************************
// **************************************************
public class Category26 : object
{
	public Category26(string name) : base()
	{
		Name = name;

		InsertDateTime =
			Dtat.DateTime.Now;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100)]
	public string Name { get; set; }
	// **********

	// **********
	// **********
	// **********
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset InsertDateTime { get; private set; }
	// **********

	// **********
	public Dtat.PersianDateTime InsertPersianDateTime
	{
		get
		{
			var result =
				InsertDateTime.ToPersianDateTime();

			return result;
		}
	}
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty11 { get; set; }
	// **********

	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty12 { get; private set; }
	// **********

	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty13 { get; protected set; }
	// **********

	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty14 { get; internal set; }
	// **********

	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty15 { get; private protected set; }
	// **********

	// **********
	/// <summary>
	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
	/// </summary>
	public int MyProperty16 { get; protected internal set; }
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	public int MyProperty21 { get; }
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.NotMapped]
	public int MyProperty22 { get; set; }
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	private int MyProperty23 { get; set; }
	// **********

	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	protected int MyProperty24 { get; set; }
	// **********

	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	internal int MyProperty25 { get; set; }
	// **********

	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	private protected int MyProperty26 { get; set; }
	// **********

	// **********
	/// <summary>
	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
	/// </summary>
	protected internal int MyProperty27 { get; set; }
	// **********
	// **********
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** Category 27 **********************************
// **************************************************
public class Category27 : object
{
	public Category27(string name) : base()
	{
		Name = name;

		InsertDateTime =
			Dtat.DateTime.Now;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100)]
	public string Name { get; set; }
	// **********

	// **********
	// **********
	// **********
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset InsertDateTime { get; private set; }
	// **********

	// **********
	public Dtat.PersianDateTime InsertPersianDateTime
	{
		get
		{
			var result =
				InsertDateTime.ToPersianDateTime();

			return result;
		}
	}
	// **********
	// **********
	// **********

	// **********
	/// <summary>
	/// Order is Zero based!
	/// Note: Using TypeName is not recommended!
	/// 
	/// Example: Default: nVarChar(100) -> Char(100)
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.Column
		(Order = 0, TypeName = "Char")]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 100)]
	public string? Description { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** UserInGroup 01 *******************************
// **************************************************
/// <summary>
/// ضمن آن‌که تفکر ذیل را اصلا توصیه نمی‌کنم، باید دقت داشته باشید
/// کار نمی‌کند EF Core کار می‌کند ولی در EF روش ذیل در
/// 
/// Error:
/// The entity type 'UserInGroup01' has multiple properties with the [Key] attribute.
/// Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'.
/// </summary>
public class UserInGroup01 : object
{
	public UserInGroup01
		(System.Guid userId, System.Guid groupId) : base()
	{
		UserId = userId;
		GroupId = groupId;
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.Column(Order = 0)]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid UserId { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.Column(Order = 1)]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid GroupId { get; private set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** UserInGroup 02 *******************************
// **************************************************
public class UserInGroup02 : object
{
	public UserInGroup02
		(System.Guid userId, System.Guid groupId) : base()
	{
		UserId = userId;
		GroupId = groupId;

		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Foreign Key
	/// 
	/// دستور ذیل، ناقص است! انشاءالله در قسمت روابط
	/// یک به چند و چند به چند به این موضوع به طور کامل می‌پردازیم
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid UserId { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Foreign Key
	/// 
	/// دستور ذیل، ناقص است! انشاءالله در قسمت روابط
	/// یک به چند و چند به چند به این موضوع به طور کامل می‌پردازیم
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid GroupId { get; private set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** User 01 **************************************
// **************************************************
public class User01 : object
{
	public User01(string username) : base()
	{
		Username = username;
		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]

	// کار نمی‌کند EF Core کار می‌کند و در EF دستور ذیل فقط در
	//[System.ComponentModel.DataAnnotations.Schema.Index
	//	(IsUnique = true)]
	public string Username { get; private set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** User 02 **************************************
// **************************************************
/// <summary>
/// نکته بسیار مهم
/// 
/// تعریف کرد Index هستند VarChar, NVarChar, Text, nText نمی‌توان برای فیلدهایی که از جنس
/// </summary>
//[Microsoft.EntityFrameworkCore.Index
//	("Username", IsUnique = true)]

// Index Name: IX_Users02_Username
[Microsoft.EntityFrameworkCore.Index
	(nameof(Username), IsUnique = true)]

//[Microsoft.EntityFrameworkCore.Index
//	(nameof(Username), IsUnique = true, Name = "Googooli")]

//[Microsoft.EntityFrameworkCore.Index
//	(propertyNames: nameof(Username), IsUnique = true, Name = "Googooli")]

//[Microsoft.EntityFrameworkCore.Index
//	(nameof(FirstName), nameof(LastName), IsUnique = false)]

// مدل نوشتن ذیل خطا می‌دهد
//[Microsoft.EntityFrameworkCore.Index
//	(propertyNames: nameof(FirstName), nameof(LastName), IsUnique = false)]

[Microsoft.EntityFrameworkCore.Index
	(nameof(FirstName), nameof(LastName), IsUnique = false)]

// خطا می‌دهد EF دستور ذیل در
//
// با اجرای دستور ذیل اتفاق جالبی رخ می‌دهد
// nvarchar(450)
// صورت می‌گیرد EF Core این عمل به طور اتوماتیک توسط
[Microsoft.EntityFrameworkCore.Index
	(nameof(Description))]
public class User02 : object
{
	public User02(string username) : base()
	{
		Username = username;
		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string Username { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string? FirstName { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 30)]
	public string? LastName { get; set; }
	// **********

	// **********
	public string? Description { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** User 03 **************************************
// **************************************************
// See:
// CreateUser03Async() Function
// **************************************************
[Microsoft.EntityFrameworkCore.Index
	(nameof(Username), IsUnique = true)]

[Microsoft.EntityFrameworkCore.Index
	(nameof(FirstName), nameof(LastName), IsUnique = false)]
public class User03 : object
{
	public User03(string username) : base()
	{
		Ordering = 10_000;
		Username = username;
		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Range
		(minimum: 1, maximum: 100_000)]
	public int Ordering { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string Username { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string? FirstName { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 30)]
	public string? LastName { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** User 04 **************************************
// **************************************************
// See:
// CreateUser04Async() Function
// **************************************************
[Microsoft.EntityFrameworkCore.Index
	(nameof(Username), IsUnique = true)]

[Microsoft.EntityFrameworkCore.Index
	(nameof(FirstName), nameof(LastName), IsUnique = false)]
public class User04 : object
{
	public User04(string username) : base()
	{
		Ordering = 10_000;
		Username = username;
		Id = System.Guid.NewGuid();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	//[System.ComponentModel.DataAnnotations.Range
	//	(minimum: 1, maximum: 100_000)]

	//[System.ComponentModel.DataAnnotations.Range
	//	(minimum: 1, maximum: 100_000,
	//	ErrorMessage = "The Ordering value should be between 1 and 100000!")]

	[System.ComponentModel.DataAnnotations.Range
		(minimum: 1, maximum: 100_000,
		ErrorMessage = "The {0} value should be between {1} and {2}!")]
	public int Ordering { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string Username { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = "First Name")]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20,
		ErrorMessage = "The {0} value must be a string with a maximum length of '{1}'!")]
	public string? FirstName { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 30)]
	public string? LastName { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// *** User 05 **************************************
// **************************************************
// See:
// CreateUser05Async() Function
// **************************************************
[Microsoft.EntityFrameworkCore.Index
	(nameof(Username), IsUnique = true)]

[Microsoft.EntityFrameworkCore.Index
	(nameof(FirstName), nameof(LastName), IsUnique = false)]
public class User05 : object
{
	public User05(string username) : base()
	{
		Ordering = 10_000;
		Username = username;
		Id = System.Guid.NewGuid();
	}

	// **********
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = "Id")]

	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = "Idd")]

	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Key]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Ordering))]

	[System.ComponentModel.DataAnnotations.Range
		(minimum: 1, maximum: 100_000,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public int Ordering { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Username))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string Username { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.FirstName))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? FirstName { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastName))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 30,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? LastName { get; set; }
	// **********
}
// **************************************************
// **************************************************
// **************************************************

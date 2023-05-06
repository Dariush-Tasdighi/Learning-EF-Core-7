namespace Domain.Features.Identity;

public class Role :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasOrdering,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	#region Constructor
	public Role(Enums.RoleEnum code,
		string name, string title) : base()
	{
		Code = code;
		Name = name;
		Title = title;

		Ordering = 10_000;

		UpdateDateTime = InsertDateTime;

		Users = new System
			.Collections.Generic.List<User>();
	}
	#endregion /Constructor

	#region Properties

	#region public bool IsActive { get; set; }
	/// <summary>
	/// وضعیت - فعال/غیرفعال
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	#endregion /public bool IsActive { get; set; }



	#region public int Ordering { get; set; }
	/// <summary>
	/// چیدمان
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Ordering))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.Range
		(minimum: 1, maximum: 100_000,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public int Ordering { get; set; }
	#endregion /public int Ordering { get; set; }

	#region public Enums.RoleEnum Code { get; set; }
	/// <summary>
	/// کد
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Code))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public Enums.RoleEnum Code { get; set; }
	#endregion /public Enums.RoleEnum Code { get; set; }



	#region public string Name { get; set; }
	/// <summary>
	/// نام
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Name))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Name,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.AToZDigitsUnderline,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Name))]
	public string Name { get; set; }
	#endregion /public string Name { get; set; }

	#region public string Title { get; set; }
	/// <summary>
	/// عنوان
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Title))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Title,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string Title { get; set; }
	#endregion /public string Title { get; set; }



	#region public System.DateTimeOffset UpdateDateTime { get; private set; }
	/// <summary>
	/// زمان ویرایش
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset UpdateDateTime { get; private set; }
	#endregion /public System.DateTimeOffset UpdateDateTime { get; private set; }

	#endregion /Properties

	#region Methods

	#region SetUpdateDateTime()
	public void SetUpdateDateTime()
	{
		UpdateDateTime =
			Dtat.DateTime.Now;
	}
	#endregion /SetUpdateDateTime()

	#endregion /Methods

	#region Collections

	public virtual System.Collections.Generic.IList<User> Users { get; private set; }

	#endregion /Collections
}

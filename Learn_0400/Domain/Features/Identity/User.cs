namespace Domain.Features.Identity;

public class User :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasOrdering,
	Dtat.Seedwork.Abstractions.IEntityHasIsDeleted,
	Dtat.Seedwork.Abstractions.IEntityHasIsTestData,
	Dtat.Seedwork.Abstractions.IEntityHasIsUndeletable,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	#region Constructor
	public User(string emailAddress,
		System.Guid roleId, string registerIP) : base()
	{
		Ordering = 10_000;

		RoleId = roleId;

		RegisterIP = registerIP;

		UpdateDateTime = InsertDateTime;

		ResetVerificationKey();
		EmailAddress = emailAddress.ToLower();
	}
	#endregion /Constructor

	#region Properties

	#region public System.Guid RoleId { get; set; }
	/// <summary>
	/// نقش کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public System.Guid RoleId { get; set; }
	#endregion /public System.Guid RoleId { get; set; }

	#region public virtual Role? Role { get; set; }
	/// <summary>
	/// نقش کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public virtual Role? Role { get; set; }
	#endregion /public virtual Role? Role { get; set; }



	#region public bool IsActive { get; set; }
	/// <summary>
	/// وضعیت
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	#endregion /public bool IsActive { get; set; }

	#region public bool IsFeatured { get; set; }
	/// <summary>
	/// ویژه بودن کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsFeatured))]
	public bool IsFeatured { get; set; }
	#endregion /public bool IsFeatured { get; set; }

	#region public bool IsTestData { get; set; }
	/// <summary>
	/// داده تستی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsTestData))]
	public bool IsTestData { get; set; }
	#endregion /public bool IsTestData { get; set; }

	#region public bool IsVerified { get; set; }
	/// <summary>
	/// تایید شده
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsVerified))]
	public bool IsVerified { get; set; }
	#endregion /public bool IsVerified { get; set; }

	#region public bool IsUndeletable { get; set; }
	/// <summary>
	/// غیر قابل حذف
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsUndeletable))]
	public bool IsUndeletable { get; set; }
	#endregion /public bool IsUndeletable { get; set; }

	#region public bool IsProfilePublic { get; set; }
	/// <summary>
	/// پروفایل به صورت عمومی قابل روئت خواهد بود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsProfilePublic))]
	public bool IsProfilePublic { get; set; }
	#endregion /public bool IsProfilePublic { get; set; }

	#region public bool IsDeleted { get; private set; }
	/// <summary>
	/// آیا به طور مجازی حذف شده؟
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsDeleted))]
	public bool IsDeleted { get; private set; }
	#endregion /public bool IsDeleted { get; private set; }

	#region public bool IsEmailAddressVerified { get; set; }
	/// <summary>
	/// نشانی پست الکترونیکی تایید شده است
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsEmailAddressVerified))]
	public bool IsEmailAddressVerified { get; set; }
	#endregion /public bool IsEmailAddressVerified { get; set; }

	#region public bool IsNationalCodeVerified { get; set; }
	/// <summary>
	/// آیا کد ملی تایید شده است یا خیر؟
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsNationalCodeVerified))]
	public bool IsNationalCodeVerified { get; set; }
	#endregion /public bool IsNationalCodeVerified { get; set; }

	#region public bool IsVisibleInContactUsPage { get; set; }
	/// <summary>
	/// در صفحه تماس با ما نمایش داده شود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsVisibleInContactUsPage))]
	public bool IsVisibleInContactUsPage { get; set; }
	#endregion /public bool IsVisibleInContactUsPage { get; set; }

	#region public bool IsCellPhoneNumberVerified { get; set; }
	/// <summary>
	/// شماره تلفن همراه تایید شده است
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified))]
	public bool IsCellPhoneNumberVerified { get; set; }
	#endregion /public bool IsCellPhoneNumberVerified { get; set; }



	#region public int Score { get; set; }
	/// <summary>
	/// امتیاز کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Score))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public int Score { get; set; }
	#endregion /public int Score { get; set; }

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



	#region public string? Username { get; set; }
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Username))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Username,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Username { get; set; }
	#endregion /public string? Username { get; set; }

	#region public string RegisterIP { get; set; }
	/// <summary>
	/// آی‌پی کاربر در زمان ثبت‌نام
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.RegisterIP))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.IP,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string RegisterIP { get; set; }
	#endregion /public string RegisterIP { get; set; }

	#region public string EmailAddress { get; set; }
	/// <summary>
	/// نشانی پست الکترونیکی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddress))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string EmailAddress { get; set; }
	#endregion /public string EmailAddress { get; set; }

	#region public string? NationalCode { get; set; }
	/// <summary>
	/// کد ملی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.NationalCode))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.FixedLength.NationalCode,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.NationalCode,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.NationalCode))]
	public string? NationalCode { get; set; }
	#endregion /public string? NationalCode { get; set; }

	#region public string? CellPhoneNumber { get; set; }
	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumber))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
	public string? CellPhoneNumber { get; set; }
	#endregion /public string? CellPhoneNumber { get; set; }

	#region public string? AdminDescription { get; set; }
	/// <summary>
	/// توضیحات مدیریتی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.AdminDescription))]
	public string? AdminDescription { get; set; }
	#endregion /public string? AdminDescription { get; set; }

	#region public string? Password { get; private set; }
	/// <summary>
	/// گذرواژه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Password))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Constants.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Password { get; private set; }
	#endregion /public string? Password { get; private set; }



	#region public string? ImageUrl { get; set; }
	/// <summary>
	/// نشانی تصویر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.ImageUrl))]
	public string? ImageUrl { get; set; }
	#endregion /public string? ImageUrl { get; set; }

	#region public string? CoverImageUrl { get; set; }
	/// <summary>
	/// نشانی تصویر کاور
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CoverImageUrl))]
	public string? CoverImageUrl { get; set; }
	#endregion /public string? CoverImageUrl { get; set; }



	#region public string? CellPhoneNumberVerificationKey { get; private set; }
	/// <summary>
	/// کد تایید شماره تلفن همراه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKey))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Constants.MinLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? CellPhoneNumberVerificationKey { get; private set; }
	#endregion /public string? CellPhoneNumberVerificationKey { get; private set; }

	#region public System.Guid EmailAddressVerificationKey { get; private set; }
	/// <summary>
	/// کد تایید نشانی پست الکترونیکی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddressVerificationKey))]
	public System.Guid EmailAddressVerificationKey { get; private set; }
	#endregion /public System.Guid EmailAddressVerificationKey { get; private set; }



	#region public System.DateTimeOffset? LastLoginDateTime { get; set; }
	/// <summary>
	/// آخرین زمان ورود به سامانه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastLoginDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? LastLoginDateTime { get; set; }
	#endregion /public System.DateTimeOffset? LastLoginDateTime { get; set; }

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

	#region public System.DateTimeOffset? DeleteDateTime { get; private set; }
	/// <summary>
	/// زمان حذف مجازی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.DeleteDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? DeleteDateTime { get; private set; }
	#endregion /public System.DateTimeOffset? DeleteDateTime { get; private set; }

	#region public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }
	/// <summary>
	/// آخرین زمان تغییر گذرواژه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastChangePasswordDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }
	#endregion /public System.DateTimeOffset? LastChangePasswordDateTime { get; private set; }

	#endregion /Properties

	#region Methods

	#region Delete()
	public void Delete()
	{
		IsDeleted = true;

		DeleteDateTime =
			Dtat.DateTime.Now;
	}
	#endregion /Delete()

	#region Undelete()
	public void Undelete()
	{
		IsDeleted = false;

		DeleteDateTime = null;
	}
	#endregion /Undelete()

	#region SetPassword()
	public void SetPassword(string? password)
	{
		if (string.IsNullOrWhiteSpace(value: password))
		{
			Password = null;
		}
		else
		{
			var passwordHash = Dtat.Security
				.Hashing.GetSha256(value: password);

			Password = passwordHash;

			LastChangePasswordDateTime = Dtat.DateTime.Now;
		}
	}
	#endregion /SetPassword()

	#region SetUpdateDateTime()
	public void SetUpdateDateTime()
	{
		UpdateDateTime =
			Dtat.DateTime.Now;
	}
	#endregion /SetUpdateDateTime()

	#region ResetVerificationKey()
	public void ResetVerificationKey()
	{
		EmailAddressVerificationKey = System.Guid.NewGuid();
	}
	#endregion /ResetVerificationKey()

	#endregion /Methods

	#region Collections
	#endregion /Collections
}

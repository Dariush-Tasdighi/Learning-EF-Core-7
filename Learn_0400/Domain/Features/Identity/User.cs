namespace Domain.Features.Identity;

public class User : Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasIsSystemic,
	Dtat.Seedwork.Abstractions.IEntityHasIsUndeletable,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	//public User(string emailAddress, System.Guid roleId) : base()
	//{
	//	//SetUpdateDateTime();
	//	UpdateDateTime = InsertDateTime;

	//	RoleId = roleId;
	//	EmailAddress = emailAddress;
	//	EmailAddressVerificationKey = System.Guid.NewGuid();

	//	UserLogins =
	//		new System.Collections.Generic.List<UserLogin>();
	//}

	public User(string emailAddress) : base()
	{
		//SetUpdateDateTime();
		UpdateDateTime =
			InsertDateTime;

		//RoleId = roleId;
		EmailAddress = emailAddress;
		EmailAddressVerificationKey = System.Guid.NewGuid();

		UserLogins =
			new System.Collections.Generic.List<UserLogin>();
	}

	// **********
	// **********
	// **********
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Role))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	//public System.Guid RoleId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public System.Guid? RoleId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]

	// نکته مهم: نباید دستور ذیل نوشته شود
	//[System.ComponentModel.DataAnnotations.Required
	//	(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public virtual Role? Role { get; set; }
	// **********
	// **********
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsSystemic))]
	public bool IsSystemic { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsProgrammer))]
	public bool IsProgrammer { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsUndeletable))]
	public bool IsUndeletable { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsProfilePublic))]
	public bool IsProfilePublic { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsEmailAddressVerified))]
	public bool IsEmailAddressVerified { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified))]
	public bool IsCellPhoneNumberVerified { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset UpdateDateTime { get; private set; }
	// **********

	// **********
	/// <summary>
	/// Note: Username is nullable!
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Username))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.MaxLength.Username,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Seedwork.Constant.RegularExpression.Username,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Username))]
	public string? Username { get; set; }
	// **********

	// **********
	/// <summary>
	/// Note: Password is nullable!
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Password))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Seedwork.Constant.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	// نکته مهم: دستور ذیل نباید نوشته شود
	// ها می‌باشد ViewModel دستور ذیل مربوط به
	//[System.ComponentModel.DataAnnotations.RegularExpression
	//	(pattern: SeedWork.Constant.RegularExpression.Password,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Password))]
	public string? Password { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.FullName))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.MaxLength.FullName,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? FullName { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddress))]

	[System.ComponentModel.DataAnnotations.Required
		(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.MaxLength.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Seedwork.Constant.RegularExpression.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string EmailAddress { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddressVerificationKey))]
	public System.Guid EmailAddressVerificationKey { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumber))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.FixedLength.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Seedwork.Constant.RegularExpression.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
	public string? CellPhoneNumber { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKey))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Seedwork.Constant.MinLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Seedwork.Constant.MaxLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? CellPhoneNumberVerificationKey { get; private set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Description))]
	public string? Description { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.AdminDescription))]
	public string? AdminDescription { get; set; }
	// **********

	public void SetUpdateDateTime()
	{
		UpdateDateTime =
			Dtat.DateTime.Now;
	}

	// **********
	public virtual System.Collections.Generic.IList<UserLogin> UserLogins { get; private set; }
	// **********
}

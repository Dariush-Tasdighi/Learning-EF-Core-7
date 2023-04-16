**************************************************
**************************************************
**************************************************
(1)

[[Application]]

	[Models]

		Role.cs
		User.cs
		DatabaseContext.cs
**************************************************

**************************************************
(2)

[[Application]]

	[Models]

		Role.cs
		User.cs

	[Data]

		DatabaseContext.cs
**************************************************

**************************************************
(3)

[[Application]]

[[Models]]

	Role.cs
	User.cs

[[Data]]

	DatabaseContext.cs
**************************************************

**************************************************
(4)

[[Application]]

[[Domain]]

	Role.cs
	User.cs

[[Persistence]]

	DatabaseContext.cs
**************************************************

**************************************************
(5)

[[Application]]

[[Domain]]

	[Features]

		[Cms]

			Post.cs
			Page.cs
			Layout.cs

		[Identity]

			Role.cs
			User.cs

[[Persistence]]

	DatabaseContext.cs
**************************************************

**************************************************
(6)

[[Application]]

[[Domain]]

	[Features]

		[Cms]

			[Posts]

				Post.cs
				PostVote.cs
				PostComment.cs

			[Pages]

				Page.cs

			[Layouts]

				Layout.cs

		[Identity]

			[Roles]

				Role.cs

			[Users]

				User.cs

[[Persistence]]

	DatabaseContext.cs
**************************************************
**************************************************
**************************************************

**************************************************
References:
**************************************************
[[Domain]]

	[[Dtat]]
	[[Resources]]
	[[Dtat.Seedwork.Abstractions]]

	Nuget(s): -

Persistence (DAL, Dal, DataAccess, Data, Persistence)

	[[Domain]]

	Nuget(s):
		Microsoft.EntityFrameworkCore.SqlServer

[[Application]]

	[[Dtat]]
	[[Domain]]
	[[Resources]]
	[[Persistence]]

	Nuget(s):
		Microsoft.EntityFrameworkCore.SqlServer
**************************************************

**************************************************
1..N = One To Many Relationship
**************************************************

**************************************************
Roles:

Id		Name

1		Simple User
2		Special User
3		Supervisor
4		Administrator

Users:

Id			RoleName			Username

1			Simple User			ali
2			Special User		reza
3			Simple User			mohammad
4			Administrator		dariush
5			Simple User			sara
6			Special User		sanaz

فرض

Simple User		-> User
Special User	-> VIP User
**************************************************

**************************************************
Roles:

Id		Name

1		Simple User
2		Special User
3		Supervisor
4		Administrator

Users:

Id			RoleId			Username

1			1				ali
2			2				reza
3			1				mohammad
4			4				dariush
5			1				sara
6			2				sanaz

Simple User		-> User
Special User	-> VIP User
**************************************************

**************************************************
Role					1..N					User

Database:

Role					1..N					User

int Id											int Id

												int RoleId (Foreign Key)

ORM or EF or Object Oriented:

Role					1..N					User

int Id											int Id

												int RoleId (Foreign Key)
IList<User> Users (Navigation Property)			Role Role (Navigation Property)
**************************************************

**************************************************
- Entity.cs
	- abstract
	- Id { get; [protected] set; }
	- InsertDateTime { get; init; }

- ValidationHelper.cs

- Role.cs
	- Constructor: Role(string name)
	- UpdateDateTime { get; init; }
	- IList<User> Users { get; private set; }
		- Navigation Property
		- 'new' in Constructor!
		- Relation One to Many (Role -> User)
	- We use Fluent API for indexing instead of 'Index' attribute!
**************************************************

**************************************************
1- Fluent API
	- In 'Data' class library:
		- DatabaseContext
			- DbSet<Domain.Role> Roles { get; set; }
			- OnModelCreating
		- In 'Configurations' Folder:
			- RoleConfiguration.cs
				- 'Index' Techniques
				- 'One To Many' Techniques
					- Convention Naming in two Models (Navigation Properties)
					- HasMany
					- WithOne
					- HasForeignKey
					- OnDelete
				- Seed Data with 'HasData'
2- In 'Application' project:
	- Program.cs
**************************************************
Convention Naming in two Models (Navigation Properties):

[Role]					[User]

Guid Id					Guid Id
						Guid RoleId

IList<User> Users		Role Role
**************************************************
ادامه دوره

ASP.NET Core Razor Pages: CRUD Template
ASP.NET Core Security   : User And The Other Models
**************************************************

**************************************************
1- Role.cs

	- DefaultRoleId

	- Constructor

		//SetUpdateDateTime();
		UpdateDateTime = InsertDateTime;

2- User.cs

	// **********
	- SuperUserId
	// **********

	// **********
	- Constructor

		UserLogins =
			new System.Collections.Generic.List<UserLogin>();
	// **********

	// **********
	// نکته مهم: نباید دستور ذیل نوشته شود
	//[System.ComponentModel.DataAnnotations.Required
	//	(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public virtual Role? Role { get; set; }
	// **********

	// **********
	public bool IsProgrammer { get; set; }
	// **********

	// **********
	public bool IsProfilePublic { get; set; }
	// **********

	// **********
	Note: Username is nullable!
	Note: Password is nullable!
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MinLength
		(length: SeedWork.Constant.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: SeedWork.Constant.FixedLength.DatabasePassword,
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
	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: SeedWork.Constant.RegularExpression.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string EmailAddress { get; set; }
	// **********

	// **********
	public System.Guid EmailAddressVerificationKey { get; [private] set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MaxLength
		(length: SeedWork.Constant.FixedLength.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: SeedWork.Constant.RegularExpression.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
	public string? CellPhoneNumber { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.MinLength
		(length: SeedWork.Constant.MinLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: SeedWork.Constant.MaxLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? CellPhoneNumberVerificationKey { get; private set; }
	// **********

	// **********
	public virtual System.Collections.Generic.IList<UserLogin> UserLogins { get; private set; }
	// **********

3- UserConfiguration.cs

	// **********
	- Index / Unique null fields!
	// **********

	// **********
	Password =
		Dtat.Hashing.GetSha256(text: "1234512345"),
	// **********

4- UserLogin.cs

5- UserLoginConfiguration.cs

6- DatabaseContext.cs

		public Microsoft.EntityFrameworkCore.DbSet<Domain.User> Users { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.UserLogin> UserLogins { get; set; }

7- Program.cs
**************************************************

**************************************************
- Remove Default Role!
- Role in user is optional not required!
**************************************************

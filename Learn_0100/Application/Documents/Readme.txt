**************************************************
(Solution Folder)
[[Class Library / Project]]
[Folder Name]
**************************************************

**************************************************
	[[Accounting]]

		[Models]

			User.cs
			Customer.cs
			DatabaseContext.cs
**************************************************

**************************************************
Table			Database			

DataTable		DataSet

Model / Entity		DatabaseContext
**************************************************

**************************************************
	[[Accounting]]

	[[Models]]

		User.cs
		Customer.cs
		DatabaseContext.cs
**************************************************

**************************************************
	[[Accounting]]

	[[Domain]]

		User.cs
		Customer.cs
		DatabaseContext.cs
**************************************************

**************************************************
	[[Accounting]]

	[[Domain]]

		User.cs
		Customer.cs

	[[DAL / Dal / DataAccess]] -> System.IO., System.Guid
		DatabaseContext.cs
**************************************************

**************************************************
	[[Accounting]]

	[[Domain]]

		User.cs
		Customer.cs

	[[Persistance]]

		DatabaseContext.cs
**************************************************

**************************************************
You can use 'DataAnnotations' without any Nugets!
**************************************************

**************************************************
// Best Practice
public int Id { get; set; }

public int ID { get; set; }

public int CategoryId { get; set; }

public int CategoryID { get; set; }

// EF Core: Error!
public int Code { get; set; }

[System.ComponentModel.DataAnnotations.Key]
public int Code { get; set; }
**************************************************

**************************************************
public int Id { get; set; }

public long Id { get; set; }

// Best Practice
public System.Guid Id { get; set; }
**************************************************

**************************************************
فلسفه لینک
LINQ Phylasophy
**************************************************
قدیما
**************************************************
sql = "SELECT * FROM Users Where Age > 20";

...
**************************************************
var currentDirectory = System.IO.DirecotryInfo("C:\Windows");

var files = currentDirectory.GetFiles();

foreach(file in files)
{
	if(file.Length > 20)
	{
		print(file.Name);
	}
}
**************************************************
جدیدا
**************************************************
var users =
	databaseContext.Users
	.Where(current => current.Age > 20)
	.ToList()
	;

foreach user in users
{
	print(user.Name);
}
**************************************************
var currentDirectory = System.IO.DirecotryInfo("C:\Windows");

var files =
	currentDirecotry.GetFiles()
	.Where(current => current.Length > 20)
	.ToList()
	;

foreach file in files
{
	print(file.Name);
}
**************************************************
جدیدا
**************************************************
var users =
	databaseContext.Users
	.Where(current => current.Age > 20)
	.OrderBy(current => current.Name)
	.ToList()
	;

foreach user in users
{
	print(user.Name);
}
**************************************************
var currentDirectory = System.IO.DirecotryInfo("C:\Windows");

var files =
	currentDirecotry.GetFiles()
	.Where(current => current.Length > 20)
	.OrderBy(current => current.Name)
	.ToList()
	;

foreach file in files
{
	print(file.Name);
}
**************************************************

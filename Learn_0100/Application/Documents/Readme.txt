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

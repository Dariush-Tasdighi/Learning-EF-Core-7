namespace Application;

public class Person : object
{
	public Person() : base()
	{
	}

	public int Age { get; set; }

	public string? FullName { get; set; }
}

public class SomeClass : object
{
	public SomeClass() : base()
	{
	}

	public void SomeFunction()
	{
		// **************************************************
		var person1 = new Person
		{
			Age = 20,
			FullName = "Ali Reza Alavi",
		};

		person1.Age = 30;
		person1.FullName = "Sara Ahmadi";
		// **************************************************

		// **************************************************
		var person2 =
			new { Age = 20, FullName = "Ali Reza Alavi" };

		// Note: Wrong Usage!
		//person2.Age = 30;
		//person2.FullName = "Sara Ahmadi";

		var age = person2.Age;
		var fullName = person2.FullName;
		// **************************************************

		// **************************************************
		var employee1 =
			new { Salary = 10_000, FName = person2.FullName };

		var employee2 =
			new { Salary = 10_000, FullName = person2.FullName };

		var employee3 =
			new { Salary = 10_000, person2.FullName };
		// **************************************************
	}
}

using System.Diagnostics.Metrics;
using System.Linq;
using Domain.Features.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application;

internal static class Program : object
{
	static Program()
	{
	}

	public static async System.Threading.Tasks.Task Main()
	{
		await CreateRoleAsync();

		await CreateUserInThreeWaysAsync();

		await LearningLinqAsync();
	}

	/// <summary>
	/// ایجاد یک نقش
	/// </summary>
	public static async System.Threading.Tasks.Task CreateRoleAsync()
	{
		var roleName = "My Role";

		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Persistence.DatabaseContext();

			var foundedRole =
				await
				databaseContext.Roles
				.Where(current => current.Name != null &&
					current.Name.ToLower() == roleName.ToLower())
				.FirstOrDefaultAsync();

			if (foundedRole is not null)
			{
				System.Console.WriteLine
					(value: $"The role already exists!");

				return;
			}

			var newRole =
				new Domain.Features.Identity.Role
				{
					Name = roleName,
				};

			var entityEntry =
				await
				databaseContext.AddAsync(entity: newRole);

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();

			System.Console.WriteLine(value: $"Role Id: {newRole.Id}");
		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);

			if (ex.InnerException is not null)
			{
				System.Console.WriteLine
					(value: ex.InnerException.Message);
			}
		}
		finally
		{
			if (databaseContext is not null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// ایجاد کاربر، به سه حالت مختلف
	/// </summary>
	public static async System.Threading.Tasks.Task CreateUserInThreeWaysAsync()
	{
		var roleName = "My Role";

		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Persistence.DatabaseContext();

			var hasAnyUser =
				await
				databaseContext.Users.AnyAsync();

			if (hasAnyUser)
			{
				System.Console.WriteLine
					(value: $"The users has been already added!");

				return;
			}

			var foundedRole =
				await
				databaseContext.Roles
				.Where(current => current.Name != null &&
					current.Name.ToLower() == roleName.ToLower())
				.FirstOrDefaultAsync();

			if (foundedRole is null)
			{
				System.Console.WriteLine
					(value: $"There is not any role with thie name '{roleName}'!");

				return;
			}

			Domain.Features.Identity.User newUser;
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entityEntry;

			// Solution (1)
			newUser =
				new Domain.Features.Identity.User
				{
					Username = "User1",
					RoleId = foundedRole.Id,
				};

			entityEntry =
				await
				databaseContext.AddAsync(entity: newUser);
			// /Solution (1)

			// Solution (2)
			newUser =
				new Domain.Features.Identity.User
				{
					Username = "User2",
					Role = foundedRole,
				};

			entityEntry =
				await
				databaseContext.AddAsync(entity: newUser);
			// /Solution (2)

			// Solution (3)
			newUser =
				new Domain.Features.Identity.User
				{
					Username = "User3",
					Role = foundedRole,
				};

			foundedRole.Users.Add(item: newUser);
			// /Solution (3)

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);

			if (ex.InnerException is not null)
			{
				System.Console.WriteLine
					(value: ex.InnerException.Message);
			}
		}
		finally
		{
			if (databaseContext is not null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}

	/// <summary>
	/// ایجاد کاربر، به سه حالت مختلف
	/// </summary>
	public static async System.Threading.Tasks.Task LearningLinqAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext =
				new Persistence.DatabaseContext();

			// **************************************************
			// سه دستور ذيل، کاملا با هم معادل می‌باشند
			// **************************************************
			// Load() -> using Microsoft.EntityFrameworkCore;
			databaseContext.Countries
				.Load();

			// استفاده می کنيم Local از

			var countries1 =
				databaseContext.Countries
				.ToList()
				;

			var countries2 =
				await
				databaseContext.Countries
				.ToListAsync()
				;
			// **************************************************
			// countries1 = countries1 = DatabaseContext.Countries.Local
			// **************************************************
			// "SELECT * FROM Countries"
			// **************************************************

			// **************************************************
			var countries3 =
				await
				databaseContext.Countries
				.Where(current => current.Code >= 10)
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Code >= 10"
			// **************************************************

			// **************************************************
			// دو دستور ذيل، کاملا با هم معادل می‌باشند
			// **************************************************
			var countries4 =
				await
				databaseContext.Countries
				.Where(current => current.Code >= 10 && current.Code <= 20)
				.ToListAsync()
				;

			var countries5 =
				await
				databaseContext.Countries
				.Where(current => current.Code >= 10)
				.Where(current => current.Code <= 20)
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Code >= 10 AND Code <= 20"
			// **************************************************

			// **************************************************
			var countries6 =
				await
				databaseContext.Countries
				.Where(current => current.Code < 10 || current.Code > 20)
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Code < 10 OR Code > 20"
			// **************************************************

			// **************************************************
			var countries7 =
				await
				databaseContext.Countries
				.Where(current => current.Name == "Iran")
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Name = 'Iran'"
			// **************************************************

			// **************************************************
			// دو دستور ذيل، کاملا با هم معادل می‌باشند
			// **************************************************
			var countries8 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower() == "Iran".ToLower())
				.ToListAsync()
				;

			var countries9 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToUpper() == "Iran".ToUpper())
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Name = 'Iran'"
			// **************************************************

			// **************************************************
			var countries10 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower().StartsWith("I".ToLower()))
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE 'I%'"
			// **************************************************

			// **************************************************
			var countries11 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower().EndsWith("n".ToLower()))
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE '%n'"
			// **************************************************

			// **************************************************
			var countries12 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower().Contains("ra".ToLower()))
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE '%ra%'"
			// **************************************************

			// **************************************************
			// Note: دقت کنيد که دستور ذيل کار نمی کند
			// **************************************************
			var text = "علی علوی";

			text =
				text.Replace(" ", "%"); // "علی%علوی"

			// "SELECT * FROM Countries WHERE Name LIKE '%علی%علوی%'"

			var countries13 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower().Contains(text.ToLower()))
				.ToListAsync()
				;

			var countries14 =
				await
				databaseContext.Countries
				.Where(current => current.Name.ToLower().Contains("علی".ToLower()))
				.Where(current => current.Name.ToLower().Contains("علوی".ToLower()))
				.ToListAsync()
				;

			var countries15 =
				await
				databaseContext.Countries
				.Where(current =>
					current.Name.ToLower().Contains("علی".ToLower())
					||
					current.Name.ToLower().Contains("علوی".ToLower()))
				.ToListAsync()
				;
			// **************************************************
			// EF -> SQL Injection Free
			// **************************************************

			// **************************************************
			var countries16 =
				await
				databaseContext.Countries
				.OrderBy(current => current.Code)
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries ORDER BY Code"
			// "SELECT * FROM Countries ORDER BY Code ASC"
			// **************************************************

			// **************************************************
			var countries17 =
				await
				databaseContext.Countries
				.OrderByDescending(current => current.Code)
				.ToListAsync()
				;
			// **************************************************
			// "SELECT * FROM Countries ORDER BY Code DESC"
			// **************************************************

			// **************************************************
			// Note: Bad Practice
			// **************************************************
			var countries18 =
				await
				databaseContext.Countries
				.OrderBy(current => current.Code)
				.Where(current => current.Code >= 10)
				.ToListAsync()
				;
			// **************************************************

			// **************************************************
			// Note: Best Practice
			// **************************************************
			var countries19 =
				await
				databaseContext.Countries
				.Where(current => current.Code >= 10)
				.OrderBy(current => current.Code)
				.ToListAsync()
				;
			// **************************************************

			// **************************************************
			// Note: Wrong Usage!
			// **************************************************
			var countries20 =
				await
				databaseContext.Countries
				.OrderBy(current => current.Code)
				.OrderBy(current => current.Name)
				.ToListAsync()
				;
			// **************************************************

			// **************************************************
			var countries21 =
				await
				databaseContext.Countries
				.OrderBy(current => current.Code)
				.ThenBy(current => current.Name)
				.ToListAsync()
				;

			var countries22 =
				await
				databaseContext.Countries
				.OrderBy(current => current.Code)
				.ThenByDescending(current => current.Name)
				.ToListAsync()
				;

			var countries23 =
				await
				databaseContext.Countries
				.OrderByDescending(current => current.Code)
				.ThenBy(current => current.Name)
				.ToListAsync()
				;

			var countries24 =
				await
				databaseContext.Countries
				.OrderByDescending(current => current.Code)
				.ThenByDescending(current => current.Name)
				.ToListAsync()
				;
			// **************************************************

			// **************************************************
			var country1 =
				await
				databaseContext.Countries
				.Where(current => current.Code == 1)
				.FirstOrDefaultAsync();

			if (country1 is not null)
			{
				var stateCount = 0;

				// In Lazy Mode:
				// If the states property with the virtual keyword:
				// States will be created and will be loaded automatically.
				//
				// In Normal Mode:
				// States is null!
				// So we catch an error!
				stateCount =
					country1.States.Count;
			}
			// **************************************************

			// **************************************************
			var states1 =
				await
				databaseContext.States
				.Where(current => current.CountryId == 1)
				.ToListAsync();
			;

			var stateCountOfSomeCountry1 = states1.Count;
			// **************************************************
			// "SELECT * FROM States WHERE CountryId = 1"
			// **************************************************

			// **************************************************
			var stateCountOfSomeCountry2 =
				await
				databaseContext.States
				.Where(current => current.CountryId == 1)
				.CountAsync();
			// **************************************************
			// "SELECT COUNT(*) FROM States WHERE CountryId = 1"
			// **************************************************

			// **************************************************
			// Undocumented!
			// **************************************************
			var country2 =
				await
				databaseContext.Countries
				.Where(current => current.Code == 1)
				.FirstOrDefaultAsync();

			if (country2 is not null)
			{
				var stateCountOfSomeCountry =
					await
					databaseContext.Entry(country2)
						.Collection(current => current.States)
						.Query()
						.CountAsync();
			}
			// **************************************************

			// **************************************************
			// فاجعه
			// **************************************************
			var country3 =
				await
				databaseContext.Countries
				.Where(current => current.Code == 1)
				.FirstOrDefaultAsync();

			if(country3 is not null)
			{
				var statesOfSomeCountry =
					country3.States
					.Where(current => current.Code <= 10)
					.ToList()
					;
			}
			// **************************************************

			// **************************************************
			var country4 =
				await
				databaseContext.Countries
				.Where(current => current.Code == 1)
				.FirstOrDefaultAsync();

			if (country4 is not null)
			{
				var statesOfSomeCountry =
					databaseContext.States
					.Where(current => current.Code <= 10)
					.Where(current => current.CountryId == country4.Id)
					.ToList()
					;
			}
			// **************************************************

			// **************************************************
			// Undocumented!
			// **************************************************
			var country5 =
				await
				databaseContext.Countries
				.Where(current => current.Code == 1)
				.FirstOrDefaultAsync();

			if (country5 is not null)
			{
				var statesOfSomeCountry =
					await
					databaseContext.Entry(country5)
					.Collection(current => current.States)
					.Query()
					.Where(state => state.Code <= 10)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code >= 10)
					.ToListAsync();

				var stateCount =
					countries[0].States.Count;
			}

			{
				// اگر بخواهيم به ازای هر کشوری، استان‌های
				// ‏مربوط به آن‌را، در همان بار اول، بارگذاری کنيم
				var countries =
					await
					databaseContext.Countries
					.Include("States")
					.Where(current => current.Code >= 10)
					.ToListAsync();

				// در این حالت امکان بی‌دقتی وجود دارد

				//var countries =
				//	await
				//	databaseContext.Countries
				//	.Include("Stats!")
				//	.Where(current => current.Code >= 10)
				//	.ToListAsync();

				var stateCount =
					countries[0].States.Count;
			}
			// **************************************************

			// **************************************************
			// Note: Strongly Typed
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Include(current => current.States)
					.Where(current => current.Code >= 10)
					.ToListAsync();

				var stateCount =
					countries[0].States.Count;
			}
			// **************************************************
			// در این حالت امکان بی‌دقتی وجود ندارد
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Include("States")
					.Include("States.Cities")
					.Where(current => current.Code >= 10)
					.ToListAsync();

				// در این حالت امکان بی‌دقتی وجود دارد

				var stateCount =
					countries[0].States.Count;
			}
			// **************************************************

			// **************************************************
			// Undocumented!
			// Note: Strongly Typed
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Include(current => current.States)
					.Include(current => current.States.Select(state => state.Cities))
					.Where(current => current.Code >= 10)
					.ToListAsync();

				var stateCount =
					countries[0].States.Count;
			}
			// **************************************************
			// در این حالت امکان بی‌دقتی وجود ندارد
			// **************************************************

			// **************************************************
			//{
			//	var countries =
			//		await
			//		databaseContext.Countries
			//		.Include(current => current.States)
			//		.Include(current => current.States.Select(state => state.Cities))
			//		.Include(current => current.States.Select(state => state.Cities.Select(city => city.Sections))
			//		.Where(current => current.Code >= 10)
			//		.ToListAsync();
			//}
			// **************************************************

		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);

			if (ex.InnerException is not null)
			{
				System.Console.WriteLine
					(value: ex.InnerException.Message);
			}
		}
		finally
		{
			if (databaseContext is not null)
			{
				await databaseContext.DisposeAsync();
			}
		}
	}
}

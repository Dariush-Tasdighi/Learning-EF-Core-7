using System.Diagnostics.Metrics;
using System.Linq;
using Domain.Features.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
			{
				// Load() -> using Microsoft.EntityFrameworkCore;
				databaseContext.Countries
					.Load();

				// استفاده می کنيم Local از

				var countries =
					databaseContext.Countries.Local;
			}

			{
				var countries =
					databaseContext.Countries
					.ToList()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code <= 10)
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Code <= 10"
			// **************************************************

			// **************************************************
			// دو دستور ذيل، کاملا با هم معادل می‌باشند
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code >= 10 && current.Code <= 20)
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code >= 10)
					.Where(current => current.Code <= 20)
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Code >= 10 AND Code <= 20"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code < 10 || current.Code > 20)
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Code < 10 OR Code > 20"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name == "Iran")
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Name = 'Iran'"
			// **************************************************

			// **************************************************
			// دو دستور ذيل، کاملا با هم معادل می‌باشند
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower() == "Iran".ToLower())
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToUpper() == "Iran".ToUpper())
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Name = 'Iran'"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().StartsWith("Ir".ToLower()))
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE 'Ir%'"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().EndsWith("an".ToLower()))
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE '%an'"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().Contains("ra".ToLower()))
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries WHERE Name LIKE '%ra%'"
			// **************************************************

			// **************************************************
			// Note: دقت کنيد که دستور ذيل کار نمی کند
			// **************************************************
			var search = "علی علوی";

			search =
				search.Replace(" ", "%"); // "علی%علوی"

			// "SELECT * FROM Countries WHERE Name LIKE '%علی%علوی%'"

			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().Contains(search.ToLower()))
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().Contains("علی".ToLower()))
					.Where(current => current.Name.ToLower().Contains("علوی".ToLower()))
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.Where(current =>
						current.Name.ToLower().Contains("علی".ToLower())
						||
						current.Name.ToLower().Contains("علوی".ToLower()))
					.ToListAsync()
					;
			}
			// **************************************************
			// EF & EF Core -> SQL Injection Free
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.OrderBy(current => current.Code)
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries ORDER BY Code"
			// "SELECT * FROM Countries ORDER BY Code ASC"
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.OrderByDescending(current => current.Code)
					.ToListAsync()
					;
			}
			// **************************************************
			// "SELECT * FROM Countries ORDER BY Code DESC"
			// **************************************************

			// **************************************************
			// Note: Bad Practice
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.OrderBy(current => current.Name)
					.Where(current => current.Code <= 10)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			// Note: Best Practice
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Code <= 10)
					.OrderBy(current => current.Name)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			// Note: Wrong Usage!
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.OrderBy(current => current.Code)
					.OrderBy(current => current.Name)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					.OrderBy(current => current.Code)
					.ThenBy(current => current.Name)
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.OrderBy(current => current.Code)
					.ThenByDescending(current => current.Name)
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.OrderByDescending(current => current.Code)
					.ThenBy(current => current.Name)
					.ToListAsync()
					;
			}

			{
				var countries =
					await
					databaseContext.Countries
					.OrderByDescending(current => current.Code)
					.ThenByDescending(current => current.Name)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Where(current => current.Code == 1)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					// In Lazy Mode:
					// If the states property with the virtual keyword:
					// States will be created and will be loaded automatically.

					// In Normal Mode:
					// stateCount is always zero!
					var stateCount =
						country.States.Count;
				}
			}
			// **************************************************

			// **************************************************
			{
				var states =
					await
					databaseContext.States
					.Where(current => current.CountryId == 1)
					.ToListAsync();
				;

				var stateCountOfSomeCountry = states.Count;
			}
			// **************************************************
			// "SELECT * FROM States WHERE CountryId = 1"
			// **************************************************

			// **************************************************
			{
				var stateCountOfSomeCountry =
					await
					databaseContext.States
					.Where(current => current.CountryId == 1)
					.CountAsync();
			}
			// **************************************************
			// "SELECT COUNT(*) FROM States WHERE CountryId = 1"
			// **************************************************

			// **************************************************
			// Undocumented!
			// **************************************************
			//{
			//	var country =
			//		await
			//		databaseContext.Countries
			//		.Where(current => current.Code == 1)
			//		.FirstOrDefaultAsync();

			//	if (country is not null)
			//	{
			//		var stateCountOfSomeCountry =
			//			await
			//			databaseContext.Entry(country)
			//				.Collection(current => current.States)
			//				.Query()
			//				.CountAsync();
			//	}
			//}
			// **************************************************

			// **************************************************
			// فاجعه
			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Where(current => current.Code == 1)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					var states =
						country.States
						.Where(current => current.Code <= 10)
						.ToList()
						;
				}
			}
			// **************************************************

			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Where(current => current.Code == 1)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					var states =
						await
						databaseContext.States
						.Where(current => current.Code <= 10)
						.Where(current => current.CountryId == country.Id)
						.ToListAsync()
						;
				}
			}
			// **************************************************

			// **************************************************
			// Undocumented!
			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Where(current => current.Code == 1)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					var statesOfSomeCountry =
						await
						databaseContext.Entry(country)
						.Collection(current => current.States)
						.Query()
						.Where(state => state.Code <= 10)
						.ToListAsync()
						;
				}
			}
			// **************************************************

			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync()
					;

				if (country is not null)
				{
					var stateCount =
						country.States.Count;
				}
			}

			{
				// اگر بخواهیم، زمانی که کشوری از بانک اطلاعاتی دریافت
				// کردیم، همه استان‌های آن نیز، در همان درخواست، منتقل شود
				// از دستور ذیل استفاده می‌کنیم
				var country =
					await
					databaseContext.Countries
					.Include("States")
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				// در این حالت امکان بی‌دقتی وجود دارد

				//var country =
				//	await
				//	databaseContext.Countries
				//	.Include("Stats")
				//	.Where(current => current.Code >= 10)
				//	.FirstOrDefaultAsync();

				if (country is not null)
				{
					var stateCount =
						country.States.Count;
				}
			}
			// **************************************************

			// **************************************************
			// Note: Strongly Typed
			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Include(current => current.States)
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					var stateCount =
						country.States.Count;
				}
			}
			// **************************************************
			// در این حالت امکان بی‌دقتی وجود ندارد
			// **************************************************

			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Include("States")
					.Include("States.Cities")
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				// در این حالت امکان بی‌دقتی وجود دارد

				if (country is not null)
				{
					var stateCount =
						country.States.Count;
				}
			}
			// **************************************************

			// **************************************************
			// Undocumented!
			// Note: Strongly Typed
			// **************************************************
			{
				var country =
					await
					databaseContext.Countries
					.Include(current => current.States)
					.Include(current => current.States.Select(state => state.Cities))
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (country is not null)
				{
					var stateCount =
						country.States.Count;
				}
			}
			// **************************************************
			// در این حالت امکان بی‌دقتی وجود ندارد
			// **************************************************

			// **************************************************
			//{
			//	var country =
			//		await
			//		databaseContext.Countries
			//		.Include(current => current.States)
			//		.Include(current => current.States.Select(state => state.Cities))
			//		.Include(current => current.States.Select(state => state.Cities.Select(city => city.Sections))
			//		.Where(current => current.Code == 10)
			//		.FirstOrDefaultAsync();

			//	if (country is not null)
			//	{
			//		var stateCount =
			//			country.States.Count;
			//	}
			//}
			// **************************************************

			// **************************************************
			{
				var city =
					await
					databaseContext.Cities
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (city is not null)
				{
					var stateName =
						city.State?.Name;
				}
			}
			// **************************************************

			// **************************************************
			{
				var city =
					await
					databaseContext.Cities
					.Include("State")
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (city is not null)
				{
					var stateName =
						city.State?.Name;

					var countryName =
						city.State?.Country?.Name;
				}
			}
			// **************************************************

			// **************************************************
			{
				var city =
					await
					databaseContext.Cities
					.Include("State")
					.Include("State.Country")
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (city is not null)
				{
					var stateName =
						city.State?.Name;

					var countryName =
						city.State?.Country?.Name;
				}
			}
			// **************************************************

			// **************************************************
			// Note: Strongly Typed
			// **************************************************
			{
				var city =
					await
					databaseContext.Cities
					.Include(current => current.State)
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (city is not null)
				{
					var stateName =
						city.State?.Name;

					var countryName =
						city.State?.Country?.Name;
				}
			}
			// **************************************************

			// **************************************************
			{
				var city =
					await
					databaseContext.Cities
					.Include(current => current.State)
					.Include(current => current.State.Country)
					.Where(current => current.Code == 10)
					.FirstOrDefaultAsync();

				if (city is not null)
				{
					var stateName =
						city.State?.Name;

					var countryName =
						city.State?.Country?.Name;
				}
			}
			// **************************************************

			// **************************************************
			// صورت مساله
			// من همه کشورهايی را می‌خواهم که
			// لااقل در نام يکی از استان‌های آن، حرف {بی} وجود داشته باشد
			// لااقل = Any

			{
				// Solution (1)
				var countries =
					await
					databaseContext.Countries
					// دقت کنيد که صرف شرط ذيل، نيازی به دستور
					// Include
					// نيست
					//.Include(current => current.States)
					.Where(current => current.States.Any
						(state => state.Name.ToLower().Contains("B".ToLower())))
					.ToListAsync()
					;
			}

			{
				// Solution (2)
				// Note: Wrong Answer
				var countries =
					await
					databaseContext.States
					.Where(current => current.Name.ToLower().Contains("B".ToLower()))
					.Select(current => current.Country)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			// صورت مساله
			// من همه کشورهايی را می‌خواهم که
			// در لااقل نام يکی از شهرهای آن، حرف {بی} وجود داشته باشد
			// **************************************************
			{
				var countries =
					await
					databaseContext.Countries
					// دقت کنيد که صرف شرط ذيل، نيازی به دستور
					// Include
					// نيست
					//.Include(current => current.States)
					//.Include(current => current.States.Select(state => state.Cities))
					.Where(current => current.States.Any(state => state.Cities.Any(city => city.Name.Contains("B"))))
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			{
				var cities =
					await
					databaseContext.Cities
					// دقت کنيد که صرف شرط ذيل، نيازی به دستور
					// Include
					// نيست
					//.Include(current => current.State)
					//.Include(current => current.State.Country)
					.Where(current => current.State.Country.Population >= 10_000_000)
					.ToListAsync()
					;
			}
			// **************************************************

			// **************************************************
			// Country -> State -> City -> Region -> Hotel
			// **************************************************
			//var hotels =
			//	await
			//	databaseContext.Hotels
			//	.ToListAsync()
			//	;

			//var hotels =
			//	await
			//	databaseContext.Hotels
			//	.Where(current => current.RegionId == someRegionId)
			//	.ToListAsync()
			//	;

			//var hotels =
			//	await
			//	databaseContext.Hotels
			//	.Where(current => current.Region.CityId == someCityId)
			//	.ToListAsync()
			//	;

			//var hotels =
			//	await
			//	databaseContext.Hotels
			//	.Where(current => current.Region.City.StateId == someStateId)
			//	.ToListAsync()
			//	;

			//var hotels =
			//	await
			//	databaseContext.Hotels
			//	.Where(current => current.Region.City.State.CountryId == someCountryId)
			//	.ToListAsync()
			//	;
			// **************************************************

			// **************************************************
			// خاطره
			// **************************************************
			//var countries =
			//	await
			//	databaseContext.Countries
			//	.Where(current => current.Code => 5)
			//	.Where(current => current.Code =< 45)
			//	.ToListAsync()
			//	;
			// **************************************************

			// **************************************************
			{
				databaseContext.Countries
					.Where(current => current.Code >= 5)
					.Where(current => current.Code <= 45)
					.Load();

				var countryCount =
					databaseContext.Countries.Local.Count;

				databaseContext.Countries
					.Where(current => current.Code >= 10)
					.Where(current => current.Code <= 50)
					.Load();

				countryCount =
					databaseContext.Countries.Local.Count;
			}
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

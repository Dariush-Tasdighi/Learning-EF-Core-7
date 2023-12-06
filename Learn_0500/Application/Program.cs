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
			{
				var search = "علی علوی";

				search =
					search.Replace(" ", "%"); // "علی%علوی"

				// "SELECT * FROM Countries WHERE Name LIKE '%علی%علوی%'"
			}
			// **************************************************

			// **************************************************
			// Dynamic Search: Introduction
			// **************************************************
			{
				var search = "علی علوی";

				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().Contains(search.ToLower()))
					.ToListAsync()
					;
			}

			{
				var search = "علی علوی";

				var keywords =
					search.Split(separator: ' ');

				//var countries =
				//	await
				//	databaseContext.Countries
				//	.Where(current => current.Name.ToLower().Contains("علی".ToLower()))
				//	.Where(current => current.Name.ToLower().Contains("علوی".ToLower()))
				//	.ToListAsync()
				//	;

				var countries =
					await
					databaseContext.Countries
					.Where(current => current.Name.ToLower().Contains(keywords[0].ToLower()))
					.Where(current => current.Name.ToLower().Contains(keywords[1].ToLower()))
					.ToListAsync()
					;
			}

			{
				var search = "علی علوی";

				var keywords =
					search.Split(separator: ' ');

				var countries =
					await
					databaseContext.Countries
					.Where(current =>
						current.Name.ToLower().Contains(keywords[0].ToLower())
						||
						current.Name.ToLower().Contains(keywords[1].ToLower()))
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
					.Include(navigationPropertyPath: "State")
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
					.Include(navigationPropertyPath: "State")
					.Include(navigationPropertyPath: "State.Country")
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
			// **************************************************
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

			// **************************************************
			// Dynamic Search:
			// **************************************************
			{
				// **************************************************
				//string? countryName = null;
				//string? countryCodeTo = null;
				//string? countryCodeFrom = null;
				// OR
				//string? countryName = "Iran";
				//string? countryCodeTo = null;
				//string? countryCodeFrom = null;
				// OR
				//string? countryName = null;
				//string? countryCodeTo = "10";
				//string? countryCodeFrom = null;
				// OR
				string? countryName = "Iran";
				string? countryCodeTo = "10";
				string? countryCodeFrom = null;
				// OR
				// Up to 8 States!
				// **************************************************

				//var data =
				//	databaseContext.Countries
				//		.Where(current => current.IsActive)
				//		;

				//var data =
				//	databaseContext.Countries
				//		.Where(current => 1 == 1)
				//		;

				var data =
					databaseContext.Countries
					.AsQueryable()
					;

				if (string.IsNullOrWhiteSpace(value: countryName) == false)
				{
					data =
						data
						.Where(current =>
							current.Name.ToLower()
							.Contains(countryName.ToLower()));
				}

				if (string.IsNullOrWhiteSpace(value: countryCodeFrom) == false)
				{
					// Note: Wrong Usage!
					//data =
					//	data
					//	.Where(current => current.Code >=
					//		System.Convert.ToInt32(countryCodeFrom));

					int countryCodeFromInt =
						System.Convert.ToInt32(value: countryCodeFrom);

					data =
						data
						.Where(current => current.Code >= countryCodeFromInt);
				}

				if (string.IsNullOrWhiteSpace(value: countryCodeTo) == false)
				{
					int countryCodeToInt =
						System.Convert.ToInt32(value: countryCodeTo);

					data =
						data
						.Where(current => current.Code >= countryCodeToInt);
				}

				data =
					data
					.OrderBy(current => current.Id);

				//data
				//	.Load();

				// يا

				// Note: Wrong Usage!
				//data =
				//	data.ToList();

				var result =
					data.ToList();
			}
			// **************************************************

			// **************************************************
			{
				var search =
					"   Ali       Reza  Iran Carpet   Ali         ";

				// یه جوری
				//string[] keywords =
				//	{ "Ali", "Reza", "Iran", "Carpet" };

				var keywords =
					new string[] { "Ali", "Reza", "Iran", "Carpet" };

				var dataTemp =
					databaseContext.Countries
					.AsQueryable();

				foreach (var keyword in keywords)
				{
					dataTemp =
						dataTemp
						.Where(current => current.Name
							.ToLower().Contains(keyword.ToLower()));
				}

				dataTemp =
					dataTemp
					.OrderBy(current => current.Code)
					;

				var dataResult =
					dataTemp.ToList();
			}
			// **************************************************

			// **************************************************
			{
				var search =
					"   Ali       Reza  Iran Carpet   Ali         ";

				//search = "Ali       Reza  Iran Carpet   Ali";
				search =
					search.Trim();

				//search = "Ali Reza Iran Carpet Ali";
				while (search.Contains(value: "  "))
				{
					search = search.Replace
						(oldValue: "  ", newValue: " ");
				}

				// keywords: ["Ali", "Reza", "Iran", "Carpet", "Ali"]
				//var keywords =
				//	search.Split(separator: ' ');

				// keywords: ["Ali", "Reza", "Iran", "Carpet"]
				var keywords =
					search.Split(separator: ' ').Distinct();

				var dataTemp =
					databaseContext.Countries
					.AsQueryable();

				foreach (var keyword in keywords)
				{
					dataTemp =
						dataTemp
						.Where(current => current.Name
							.ToLower().Contains(keyword.ToLower()));
				}

				dataTemp =
					dataTemp
					.OrderBy(current => current.Code)
					;

				var dataResult =
					dataTemp.ToList();
			}
			// **************************************************

			// **************************************************
			{
				var search =
					"   Ali       Reza  Iran Carpet   Ali         ";

				search =
					search.Trim();

				while (search.Contains(value: "  "))
				{
					search = search.Replace
						(oldValue: "  ", newValue: " ");
				}

				var keywords =
					search.Split(separator: ' ').Distinct();

				var dataTemp =
					databaseContext.Countries
					.AsQueryable();

				// Mr. Farshad Rabiei
				// دستور ذیل باید چک شود
				dataTemp =
					dataTemp.Where(current => keywords.Contains(current.Name));

				dataTemp =
					dataTemp
					.OrderBy(current => current.Code)
					;

				var dataResult =
					dataTemp.ToList();
			}
			// **************************************************

			// **************************************************
			// Learning Traditional LINQ
			// **************************************************
			// دستورات ذيل کاملا با هم معادل هستند
			// **************************************************
			{
				databaseContext.Countries
					.Load();

				// databaseContext.Countries.Local
			}

			{
				var data1 =
					databaseContext.Countries
					.ToList()
					;
			}

			{
				var data2 =
					from Country in databaseContext.Countries
					select Country
					;
			}
			// **************************************************
			// SELECT * FROM Countries
			// **************************************************

			// **************************************************
			// ها Country آرایه‌ای از
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.ToLower().Contains("Iran".ToLower())
					select Country
					;
			}
			// **************************************************

			// **************************************************
			// ها Country آرایه‌ای از
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.ToLower().Contains("Iran".ToLower())
					orderby Country.Name
					select Country
					;

				foreach (var currentCountry in data)
				{
					System.Console.WriteLine
						(value: currentCountry.Name);
				}
			}
			// **************************************************

			// **************************************************
			// (A)
			// ها string آرایه‌ای از
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.ToLower().Contains("Iran".ToLower())
					orderby Country.Name
					select Country.Name
					;

				// Select Name From Countries

				foreach (var currentCountryName in data)
				{
					System.Console.WriteLine
						(value: currentCountryName);
				}
			}
			// **************************************************

			// **************************************************
			// Note: See Learning Anonymous Object File!
			// **************************************************

			// **************************************************
			// (B)
			// ها object آرایه‌ای از
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.ToLower().Contains("Iran".ToLower())
					orderby Country.Name
					select new { Name = Country.Name }
					;

				foreach (var currentPartialCountry in data)
				{
					System.Console.WriteLine
						(value: currentPartialCountry.Name);
				}
			}
			// **************************************************

			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.ToLower().Contains("Iran".ToLower())
					orderby Country.Name
					select new { Country.Name }
					//select new { Name = Country.Name }
					;

				foreach (var currentPartialCountry in data)
				{
					System.Console.WriteLine
						(value: currentPartialCountry.Name);
				}
			}
			// **************************************************

			// **************************************************
			// (C)
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.Contains("Iran")
					orderby Country.Name
					select new { Baghali = Country.Name }
					;

				foreach (var currentPartialCountry in data)
				{
					System.Console.WriteLine
						(value: currentPartialCountry.Baghali);
				}
			}
			// **************************************************

			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.Contains("Iran")
					orderby Country.Name
					select new { Size = Country.Population, Country.Name }
					;

				foreach (var currentPartialCountry in data)
				{
					System.Console.WriteLine
						(value: currentPartialCountry.Name);
				}
			}
			// **************************************************

			// **************************************************
			// (D1)
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.Contains("Iran")
					orderby Country.Name
					select (new ViewModels.CountryViewModel1() { NewName = Country.Name })
					;

				foreach (var currentCountryViewModel in data)
				{
					currentCountryViewModel.NewName += "!";

					System.Console.WriteLine
						(value: currentCountryViewModel.NewName);
				}
			}
			// **************************************************

			// **************************************************
			// (D2)
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.Contains("Iran")
					orderby Country.Name
					select (new ViewModels.CountryViewModel2() { Name = Country.Name })
					;

				foreach (var currentCountryViewModel in data)
				{
					currentCountryViewModel.Name += "!";

					System.Console.WriteLine
						(value: currentCountryViewModel.Name);
				}
			}
			// **************************************************

			// **************************************************
			// (D3)
			// Note: Wrong Usage!
			// **************************************************
			//{
			//	var data =
			//		from Country in databaseContext.Countries
			//		where Country.Name.Contains("Iran")
			//		orderby Country.Name
			//		select (new ViewModels.CountryViewModel2() { Country.Name })
			//		;

			//	foreach (var currentCountryViewModel in data)
			//	{
			//		currentCountryViewModel.Name += "!";

			//		System.Console.WriteLine
			//			(value: currentCountryViewModel.Name);
			//	}
			//}
			// **************************************************

			// **************************************************
			// (E)
			// Note: متاسفانه دستور ذیل کار نمی کند
			// **************************************************
			{
				var data =
					from Country in databaseContext.Countries
					where Country.Name.Contains("Iran")
					orderby Country.Name
					select new Domain.Features.Identity.Country(Country.Name)
					//select new Domain.Features.Identity.Country() { Name = Country.Name }
					;

				foreach (var currentCountry in data)
				{
					System.Console.WriteLine
						(value: currentCountry.Name);
				}
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

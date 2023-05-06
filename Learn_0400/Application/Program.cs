using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application
{
	internal static class Program : object
	{
		static Program()
		{
		}

		public static async System.Threading.Tasks.Task Main()
		{
			// **************************************************
			await CreateRoleAsync();
			// **************************************************

			// **************************************************
			await CreateSimpleUserAsync();
			// **************************************************

			// **************************************************
			await CreateSomeUserLoginsAsync();
			// **************************************************

			// **************************************************
			await DeleteUserAsync();
			// **************************************************
		}

		private static async System.Threading.Tasks.Task CreateRoleAsync()
		{
			Persistence.DatabaseContext? databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				var roleName = "مدیر";

				var foundedRole =
					await
					databaseContext.Roles
					.Where(current => current.Name.ToLower() == roleName.ToLower())
					.FirstOrDefaultAsync();

				if (foundedRole != null)
				{
					System.Console.WriteLine
						(value: $"This role [{roleName}] already exists!");

					return;
				}

				var role =
					new Domain.Features.Identity.Role
					(code: Domain.Features.Identity.Enums.RoleEnum.SimpleUser, name:
					nameof(Domain.Features.Identity.Enums.RoleEnum.SimpleUser), title: "Simple User")
					{
						IsActive = true,
					};

				var isValid =
					Domain.Seedwork.ValidationHelper.IsValid(entity: role);

				var results =
					Domain.Seedwork.ValidationHelper.GetValidationResults(entity: role);

				if (isValid)
				{
					var entityEntry =
						await
						databaseContext.AddAsync(entity: role);

					var affectedRows =
						await
						databaseContext.SaveChangesAsync();
				}
			}
			catch (System.Exception ex)
			{
				// Log Error!

				System.Console.WriteLine(value: ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					await databaseContext.DisposeAsync();
				}
			}
		}

		private static async System.Threading.Tasks.Task CreateSimpleUserAsync()
		{
			Persistence.DatabaseContext? databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				var simpleUserRole =
					await
					databaseContext.Roles
					.Where(current => current.Code ==
						Domain.Features.Identity.Enums.RoleEnum.SimpleUser)
					.FirstOrDefaultAsync();

				if (simpleUserRole is null)
				{
					System.Console.WriteLine
						(value: $"There is not simple user role!");

					return;
				}

				var emailAddress =
					"DariushTasdighi@GMail.com";

				var foundedUser =
					await
					databaseContext.Users
					.Where(current => current.EmailAddress.ToLower() == emailAddress.ToLower())
					.FirstOrDefaultAsync();

				if (foundedUser is not null)
				{
					System.Console.WriteLine
						(value: $"This user [{emailAddress}] already exists!");

					return;
				}

				var user =
					new Domain.Features.Identity.User(emailAddress:
					emailAddress, roleId: simpleUserRole.Id, registerIP: "127.0.0.1")
					{
						IsActive = true,
						IsEmailAddressVerified = true,

						CellPhoneNumber = "09121086174",
					};

				user.SetPassword(password: "1234512345");

				var isValid =
					Domain.Seedwork.ValidationHelper.IsValid(entity: user);

				var results =
					Domain.Seedwork.ValidationHelper.GetValidationResults(entity: user);

				if (isValid)
				{
					var entityEntry =
						await
						databaseContext.AddAsync(entity: user);

					var affectedRows =
						await
						databaseContext.SaveChangesAsync();
				}
			}
			catch (System.Exception ex)
			{
				// Log Error!

				System.Console.WriteLine(value: ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					await databaseContext.DisposeAsync();
				}
			}
		}

		private static async System.Threading.Tasks.Task CreateSomeUserLoginsAsync()
		{
			Persistence.DatabaseContext? databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				var emailAddress =
					"DariushTasdighi@GMail.com";

				var foundedUser =
					await
					databaseContext.Users
					.Where(current => current.EmailAddress.ToLower() == emailAddress.ToLower())
					.FirstOrDefaultAsync();

				if (foundedUser == null)
				{
					System.Console.WriteLine
						(value: $"There is not such as user [{emailAddress}]!");

					return;
				}

				//for (int index = 1; index <= 5; index++)
				//{
				//	var usesrIP =
				//		$"{index}.{index}.{index}.{index}";

				//	//var userLogin =
				//	//	new Domain.UserLogin(userId: foundedUser.Id, userIP: usesrIP);

				//	var isValid =
				//		Domain.Seedwork.ValidationHelper.IsValid(entity: userLogin);

				//	var results =
				//		Domain.Seedwork.ValidationHelper.GetValidationResults(entity: userLogin);

				//	if (isValid)
				//	{
				//		var entityEntry =
				//			await
				//			databaseContext.AddAsync(entity: userLogin);

				//		var affectedRows =
				//			await
				//			databaseContext.SaveChangesAsync();
				//	}
				//}
			}
			catch (System.Exception ex)
			{
				// Log Error!

				System.Console.WriteLine(value: ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					await databaseContext.DisposeAsync();
				}
			}
		}

		private static async System.Threading.Tasks.Task DeleteUserAsync()
		{
			Persistence.DatabaseContext? databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				var emailAddress =
					"DariushTasdighi@GMail.com";

				var foundedUser =
					await
					databaseContext.Users
					.Where(current => current.EmailAddress.ToLower() == emailAddress.ToLower())
					.FirstOrDefaultAsync();

				if (foundedUser == null)
				{
					System.Console.WriteLine
						(value: $"There is not such as user [{emailAddress}]!");

					return;
				}

				var entityEntry =
					databaseContext.Remove(entity: foundedUser);

				var affectedRows =
					await
					databaseContext.SaveChangesAsync();
			}
			catch (System.Exception ex)
			{
				// Log Error!

				System.Console.WriteLine(value: ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					await databaseContext.DisposeAsync();
				}
			}
		}
	}
}

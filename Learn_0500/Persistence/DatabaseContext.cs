using Domain.Features.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DatabaseContext :
	Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext() : base()
	{
		// **************************************************
		Database.EnsureCreated();
		// **************************************************
	}

	public Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<City> Cities { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<State> States { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Country> Countries { get; set; }

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0500;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		// using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(DatabaseContext).Assembly);
	}
}

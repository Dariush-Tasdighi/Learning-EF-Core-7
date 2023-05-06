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

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0400;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		// using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}

	//protected override void OnModelCreating(ModelBuilder modelBuilder)
	//{
	//	base.OnModelCreating(modelBuilder);
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Solution (1)
		//modelBuilder
		//	.Entity<Domain.Role>()
		//	.HasIndex(current => new { current.Name })
		//	.IsUnique(unique: true)
		//	;
		// /Solution (1)

		// Solution (2)
		//modelBuilder.ApplyConfiguration
		//	(configuration: new Configurations.RoleConfiguration());
		// /Solution (2)

		// Solution (3)
		//new Configurations.RoleConfiguration()
		//	.Configure(builder: modelBuilder.Entity<Domain.Role>());
		// /Solution (3)

		// Solution (4)
		//modelBuilder.ApplyConfigurationsFromAssembly
		//	(assembly: System.Reflection.Assembly.GetExecutingAssembly());
		// /Solution (4)

		// Solution (5)
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(DatabaseContext).Assembly);
		// /Solution (5)
	}
}

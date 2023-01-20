using Microsoft.EntityFrameworkCore;

namespace Models;

public class DatabaseContext :
	Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext() : base()
	{
		// TODO: Never use in production mode
		Database.EnsureCreated();
	}

	public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }

	//protected override void OnConfiguring
	//	(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	//{
	//	base.OnConfiguring(optionsBuilder);
	//}

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// ***********************************
		// *** Windows Authentication Mode ***
		// ***********************************

		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;";

		// *********************************************************************
		// *** SQL Server Authentication Mode without TrustServerCertificate ***
		// *********************************************************************

		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;User ID=sa;Password=1234512345;";

		// ******************************************************************
		// *** SQL Server Authentication Mode with TrustServerCertificate ***
		// ******************************************************************

		var connectionString =
			"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;User ID=sa;Password=1234512345;";

		// UseSqlServer() -> using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}
}

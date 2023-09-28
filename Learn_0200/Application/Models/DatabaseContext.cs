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

	public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }

	//protected override void OnConfiguring
	//	(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	//{
	//	base.OnConfiguring(optionsBuilder);
	//}

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// ******************************************************************
		// https://www.connectionstrings.com/sql-server/
		// Connect Timeout or Connection Timeout: Default: 15 Seconds
		// ******************************************************************

		// ******************************************************************
		// *** Windows Authentication Mode without TrustServerCertificate ***
		// ******************************************************************
		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;";
		// ******************************************************************

		// ***************************************************************
		// *** Windows Authentication Mode with TrustServerCertificate ***
		// ***************************************************************
		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";
		// ******************************************************************

		// *********************************************************************
		// *** SQL Server Authentication Mode without TrustServerCertificate ***
		// *********************************************************************
		//var connectionString =
		//	"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true";
		// ******************************************************************

		// ******************************************************************
		// *** SQL Server Authentication Mode with TrustServerCertificate ***
		// ******************************************************************
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";
		// ******************************************************************

		// UseSqlServer -> using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}
}

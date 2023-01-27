**************************************************
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.2

Install-Package Microsoft.EntityFrameworkCore.SqlServer

<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.2" />
**************************************************

**************************************************
protected override void OnConfiguring
	(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
{
}
**************************************************

**************************************************
https://www.connectionstrings.com/sql-server/

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
	//	"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;";
	// ******************************************************************

	// ******************************************************************
	// *** SQL Server Authentication Mode with TrustServerCertificate ***
	// ******************************************************************
	var connectionString =
		"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";
	// ******************************************************************

	Connect Timeout or Connection Timeout: Default (15 Seconds)
**************************************************

**************************************************
Database.EnsureDeleted();

Note: Should be before 'OnConfiguring' method!
**************************************************

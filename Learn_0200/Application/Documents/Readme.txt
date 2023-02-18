**************************************************
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/

Manage NuGet Packages For Solution...

	Search:

		Microsoft.EntityFrameworkCore.SqlServer

			Install

Package Manager Console:

	Install-Package Microsoft.EntityFrameworkCore.SqlServer

In File: Application.csproj

	<ItemGroup>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.2" />
	</ItemGroup>
**************************************************

**************************************************
In File: DatabaseContext.cs

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// ******************************************************************
		// *** SQL Server Authentication Mode with TrustServerCertificate ***
		// ******************************************************************
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";
		// ******************************************************************

		// UseSqlServer() -> using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}
**************************************************

**************************************************
In File: DatabaseContext.cs

	In Constructor:

		public DatabaseContext() : base()
		{
			// TODO: Never use in production mode
			Database.EnsureCreated();
		}

	Note: Should be before 'OnConfiguring' method!
**************************************************

**************************************************
Dependencies:

	<PackageReference Include="Microsoft.EntityFrameworkCore.Analyzers" Version="7.0.2" />



	<PackageReference Include="Microsoft.EntityFrameworkCore.Abstractions" Version="7.0.2" />



	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.2" />

		Microsoft.Extensions.Logging (>= 7.0.0)
		Microsoft.Extensions.Caching.Memory (>= 7.0.0)
		Microsoft.EntityFrameworkCore.Analyzers (>= 7.0.2)
		Microsoft.Extensions.DependencyInjection (>= 7.0.0)
		Microsoft.EntityFrameworkCore.Abstractions (>= 7.0.2)



	Microsoft.EntityFrameworkCore.Relational

		Microsoft.EntityFrameworkCore (>= 7.0.2)
		Microsoft.Extensions.Configuration.Abstractions (>= 7.0.0)



	<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.2" />

		Microsoft.Data.SqlClient (>= 5.0.1)
		Microsoft.EntityFrameworkCore.Relational (>= 7.0.2)



	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.2">
		<PrivateAssets>all</PrivateAssets>
		<IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
	</PackageReference>

		Humanizer.Core (>= 2.14.1)
		Mono.TextTemplating (>= 2.2.1)
		Microsoft.Extensions.DependencyModel (>= 7.0.0)
		Microsoft.EntityFrameworkCore.Relational (>= 7.0.2)



	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.2">
		<PrivateAssets>all</PrivateAssets>
		<IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
	</PackageReference>

		Microsoft.EntityFrameworkCore.Design (>= 7.0.2)



	<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="7.0.2" />

		Microsoft.EntityFrameworkCore (>= 7.0.2)



	<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="7.0.2" />

		Castle.Core (>= 5.1.0)
		Microsoft.EntityFrameworkCore (>= 7.0.2)



	<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="7.0.2" />

		Microsoft.Extensions.Identity.Stores (>= 7.0.2)
		Microsoft.EntityFrameworkCore.Relational (>= 7.0.2)
**************************************************

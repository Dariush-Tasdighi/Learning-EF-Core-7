namespace Persistence.Configurations.Features.Idenity;

internal sealed class RoleConfiguration : object, Microsoft
	.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Features.Identity.Role>
{
	public RoleConfiguration() : base()
	{
	}

	public void Configure(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.Features.Identity.Role> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.Property(current => current.Name)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.HasIndex(current => new { current.Title })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.HasIndex(current => new { current.Code })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.Users)
			.WithOne(other => other.Role)
			.IsRequired(required: true)
			.HasForeignKey(other => other.RoleId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}

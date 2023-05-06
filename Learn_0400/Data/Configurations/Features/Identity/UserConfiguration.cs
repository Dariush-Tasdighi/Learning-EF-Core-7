namespace Persistence.Configurations.Features.Idenity;

internal sealed class UserConfiguration : object, Microsoft
	.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Features.Identity.User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.Features.Identity.User> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.Property(current => current.NationalCode)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.NationalCode })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.EmailAddress)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.EmailAddress })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.HasIndex(current => new { current.EmailAddressVerificationKey })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Username)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.Username })
			.IsUnique(unique: true)
			;

		//builder.HasIndex(current => current.Username)
		//	.IsUnique(unique: true)
		//	// HasFilter -> using Microsoft.EntityFrameworkCore;
		//	.HasFilter("[Username] IS NOT NULL");
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.CellPhoneNumber)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.CellPhoneNumber })
			.IsUnique(unique: true)
			;

		//builder.HasIndex(current => current.CellPhoneNumber)
		//	.IsUnique(unique: true)
		//	// HasFilter -> using Microsoft.EntityFrameworkCore;
		//	.HasFilter("[CellPhoneNumber] IS NOT NULL");
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.CellPhoneNumberVerificationKey)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.CellPhoneNumberVerificationKey })
			.IsUnique(unique: true)
			;

		//builder.HasIndex(current => current.CellPhoneNumberVerificationKey)
		//	.IsUnique(unique: true)
		//	// HasFilter -> using Microsoft.EntityFrameworkCore;
		//	.HasFilter("[CellPhoneNumberVerificationKey] IS NOT NULL");
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Password)
			.IsUnicode(unicode: false)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
	}
}

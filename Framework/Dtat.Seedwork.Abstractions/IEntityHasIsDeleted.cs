namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasIsDeleted
{
	bool IsDeleted { get; }

	System.DateTimeOffset? DeleteDateTime { get; }

	void Delete();

	void Undelete();
}

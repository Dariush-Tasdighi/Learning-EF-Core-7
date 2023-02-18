namespace Domain.SeedWork
{
	public interface IEntityHasUpdateDateTime
	{
		System.DateTimeOffset UpdateDateTime { get; }

		void SetUpdateDateTime();
	}
}

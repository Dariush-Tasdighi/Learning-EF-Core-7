namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCode<TCode>
{
	TCode Code { get; }
}

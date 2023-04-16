namespace Dtat.Seedwork.Abstractions;

//public interface IEntity
//{
//	public int Id { get; }

//	public System.DateTimeOffset InsertDateTime { get; }
//}

//public interface IEntity
//{
//	public long Id { get; }

//	public System.DateTimeOffset InsertDateTime { get; }
//}

//public interface IEntity
//{
//	public System.Guid Id { get; }

//	public System.DateTimeOffset InsertDateTime { get; }
//}

//public interface IEntity<T>
//{
//	public T Id { get; }

//	public System.DateTimeOffset InsertDateTime { get; }
//}

public interface IEntity<TIdentity>
{
	public TIdentity Id { get; }

	public System.DateTimeOffset InsertDateTime { get; }
}

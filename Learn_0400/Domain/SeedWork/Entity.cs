namespace Domain.Seedwork;

public abstract class Entity : object,
	Dtat.Seedwork.Abstractions.IEntity<System.Guid>
{
	#region Constructor
	public Entity() : base()
	{
		Id = System
			.Guid.NewGuid();

		InsertDateTime = Dtat.DateTime.Now;
	}
	#endregion /Constructor

	#region Properties

	#region public System.Guid Id { get; protected set; }
	/// <summary>
	/// شناسه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; protected set; }
	#endregion /public System.Guid Id { get; protected set; }

	#region public System.DateTimeOffset InsertDateTime { get; private set; }
	/// <summary>
	/// زمان ایجاد
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsertDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset InsertDateTime { get; private set; }
	#endregion /public System.DateTimeOffset InsertDateTime { get; private set; }

	#endregion /Properties
}

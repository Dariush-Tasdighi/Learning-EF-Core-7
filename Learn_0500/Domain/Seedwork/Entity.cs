namespace Domain.Seedwork;

public abstract class Entity : object
{
	public Entity() : base()
	{
	}

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(databaseGeneratedOption:
		System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Id { get; private set; }
}

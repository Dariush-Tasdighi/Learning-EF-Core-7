namespace Domain.Features.Identity;

public class City : Seedwork.Entity
{
	public City(string name) : base()
	{
		Name = name;
	}

	public int StateId { get; set; }
	public virtual State? State { get; set; }

	public int Code { get; set; }

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 50)]
	public string Name { get; set; }
}

namespace Domain.Features.Identity;

public class Country : Seedwork.Entity
{
	public Country(string name) : base()
	{
		Name = name;

		States = new System
			.Collections.Generic.List<State>();
	}

	public int Code { get; set; }

	public int Population { get; set; }

	public int HealthyRate { get; set; }

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string Name { get; set; }

	public virtual System.Collections.Generic.IList<State> States { get; private set; }
}

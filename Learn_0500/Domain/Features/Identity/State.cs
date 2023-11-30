namespace Domain.Features.Identity;

public class State : Seedwork.Entity
{
	public State(string name) : base()
	{
		Name = name;

		Cities = new System
			.Collections.Generic.List<City>();
	}

	public int CountryId { get; set; }

	public virtual Country? Country { get; set; }

	public int Code { get; set; }

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string Name { get; set; }

	public virtual System.Collections.Generic.IList<City> Cities { get; private set; }
}

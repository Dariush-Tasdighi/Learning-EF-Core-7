namespace Domain.Features.Identity;

public class Role : Seedwork.Entity
{
	public Role() : base()
	{
		Ordering = 10_000;

		Users = new System
			.Collections.Generic.List<User>();
	}

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string? Name { get; set; }

	public virtual System.Collections.Generic.IList<User> Users { get; private set; }
}

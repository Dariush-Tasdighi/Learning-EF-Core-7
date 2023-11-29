namespace Domain.Features.Identity;

public class User : Seedwork.Entity
{
	public User() : base()
	{
		Ordering = 10_000;
	}

	public int RoleId { get; set; }
	public virtual Role? Role { get; set; }

	public int Ordering { get; set; }
	public bool IsActive { get; set; }

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 20)]
	public string? Username { get; set; }
}

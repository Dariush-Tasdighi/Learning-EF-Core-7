namespace Domain.Features.Identity.Enums;

public enum RoleEnum : int
{
	SimpleUser = 0,
	SpecialUser = 100,

	Supervisor = 200,

	Administrator = 300,
	ApplicationOwner = 400,

	Programmer = 900,
}

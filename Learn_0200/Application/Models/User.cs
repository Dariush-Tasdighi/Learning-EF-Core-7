namespace Models;

/// <summary>
/// کلاس کاربر
/// </summary>
public class User : object
{
	#region Constructor
	/// <summary>
	/// سازنده
	/// </summary>
	/// <param name="username">شناسه کاربری</param>
	/// <param name="password">گذرواژه</param>
	public User(string username, string password) : base()
	{
		Username = username;
		Password = password;
	}
	#endregion /Constructor

	#region Properties

	#region public int Id { get; set; }
	/// <summary>
	/// شناسه
	/// </summary>
	public int Id { get; set; }
	#endregion /public int Id { get; set; }

	#region public string Username { get; set; }
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	public string Username { get; set; }
	#endregion /public string Username { get; set; }

	#region public string Password { get; set; }
	/// <summary>
	/// گذرواژه
	/// </summary>
	public string Password { get; set; }
	#endregion /public string Password { get; set; }

	#region public string? FullName { get; set; }
	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	public string? FullName { get; set; }
	#endregion /public string? FullName { get; set; }

	#endregion /Properties
}

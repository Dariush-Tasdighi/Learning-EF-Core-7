using System.Linq;

namespace Application;

public static class LinqPhilosophy : object
{
	static LinqPhilosophy()
	{
	}

	public static void WorkinngOnDatabase()
	{
		//var query =
		//	"SELECT * FROM Users WHERE Age >= 25 AND Age <= 35 ORDER BY FullName ASC";

		// ارسال به بانک اطلاعاتی برای بدست آوردن اطلاعات اشخاص
	}

	public static void WorkingOnFiles()
	{
		var path =
			"C:\\WINDOWS";

		var directoryInfo =
			new System.IO.DirectoryInfo(path: path);

		var files =
			directoryInfo.GetFiles();

		foreach (System.IO.FileInfo fileInfo in files)
		{
			System.Console.WriteLine
				(value: fileInfo.Name);
		}

		foreach (var fileInfo in files)
		{
			if (fileInfo.Length is >= (25 * 1024) and <= (35 * 1024))
			{
				System.Console.WriteLine
					(value: fileInfo.Name);
			}
		}

		// صورت مساله‌ای که چهارشاخ گاردان را پایین می‌آورد

		// حال می‌خواهیم تمام فایل‌هایی را نشان دهد که سایز آنها بین
		// بیست و پنج کیلو بایت تا سی و پنج کیلو بایت بوده
		// و مرتب شده بر حسب نام فایل‌ها باشد
	}

	public static void WorkingOnXml()
	{
		// XmlDocument, XmlReader,...
	}

	public static void WorkinngOnDatabaseWithLinq()
	{
		var databaseContext =
			new Persistence.DatabaseContext();

		var users =
			databaseContext.Users
			.Where(current => current.Age >= 25 && current.Age <= 35)
			.OrderBy(current => current.FullName)
			.ToList()
			;
	}

	public static void WorkingOnFilesWithLinq()
	{
		var path =
			"C:\\WINDOWS";

		var directoryInfo =
			new System.IO.DirectoryInfo(path: path);

		var files =
			directoryInfo.GetFiles()
			.Where(current => current.Length >= 25 * 1024 && current.Length <= 35 * 1024)
			.OrderBy(current => current.Name)
			.ToList()
			;
	}
}

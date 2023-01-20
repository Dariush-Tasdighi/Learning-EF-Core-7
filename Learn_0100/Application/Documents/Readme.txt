**************************************************
You can use 'DataAnnotations' without any Nugets!
**************************************************

**************************************************
// Best Practice
public int Id { get; set; }

public int ID { get; set; }

public int CategoryId { get; set; }

public int CategoryID { get; set; }

// EF Core: Error!
public int Code { get; set; }

[System.ComponentModel.DataAnnotations.Key]
public int Code { get; set; }
**************************************************

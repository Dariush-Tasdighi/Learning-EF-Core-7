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

**************************************************
// Best Practice
public long Id { get; set; }

public long ID { get; set; }

public long CategoryId { get; set; }

public long CategoryID { get; set; }

// EF Core: Error!
public long Code { get; set; }

[System.ComponentModel.DataAnnotations.Key]
public long Code { get; set; }
**************************************************

**************************************************
// Best Practice
public System.Guid Id { get; set; }

public System.Guid ID { get; set; }

public System.Guid CategoryId { get; set; }

public System.Guid CategoryID { get; set; }

// EF Core: Error!
public System.Guid Code { get; set; }

[System.ComponentModel.DataAnnotations.Key]
public System.Guid Code { get; set; }
**************************************************

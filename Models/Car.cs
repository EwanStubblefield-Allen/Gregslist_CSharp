

namespace gregslist_csharp.Models;

public class Car
{
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public string Color { get; set; }
  public int? Year { get; set; }
  public double? Price { get; set; }

  public bool? OwnedByGrandma { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

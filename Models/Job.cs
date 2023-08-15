using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_csharp.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Position { get; set; }
    public int? Salary { get; set; }
    public bool? IsFullTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public enum Schedule
    {
      Weekdays,
      Weekends,
      Flexible,
      OnCall
    }
    public string Description { get; set; }
  }
}
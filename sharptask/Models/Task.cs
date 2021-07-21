using System;

namespace sharptask.Models
{
  public class ListTask
  {
    public int Id { get; set; }
    public int ListId { get; set; }
    public string CreatorId { get; set; }
    public string TaskName { get; set; }
    public DateTime Create_Time { get; set; }
    public DateTime Update_Time { get; set; }
  }

}
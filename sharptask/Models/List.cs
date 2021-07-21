using System;

namespace sharptask.Models
{
  public class List
  {
    public int Id { get; set; }

    public string CreatorId { get; set; }
    public string ListName { get; set; }
    public DateTime Create_Time { get; set; }
    public DateTime Update_Time { get; set; }
    public Profile Creator { get; set; }
  }

}
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Savory.Models
{
  public class Baker
  {
    public Baker() : base()
    {
      
    }
    public int BakerId {get; set;}
    public string Name {get; set;}
    public virtual ApplicationUser User {get; set;}
    
  }
}
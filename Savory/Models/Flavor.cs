using System.Collections.Generic;

namespace Savory.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }
    public int FlavorId {get; set;}
    public string FlavorName {get; set;}
    // public virtual ApplicationUser User {get; set;}
    public virtual ICollection<FlavorTreat> Flavors {get; set;}

  } 
}
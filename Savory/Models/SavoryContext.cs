using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Savory.Models
{
  public class SavoryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }
    public DbSet<Baker> Bakers { get; set; }

    public SavoryContext(DbContextOptions options) : base(options) { }
  }
}
using Microsoft.EntityFrameworkCore;

namespace Savory.Models
{
  public class SavoryContext : DbContext
  {
    public virtual DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public SavoryContext(DbContextOptions options) : base(options) { }
  }
}
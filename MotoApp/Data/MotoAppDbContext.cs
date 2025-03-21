using MotoApp.Entities;
using Microsoft.EntityFrameworkCore;
namespace MotoApp.Data;

public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
        : base(options)
    { }
    
    public DbSet<Car> Car => Set<Car>();
    public DbSet<Employee> Employee => Set<Employee>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

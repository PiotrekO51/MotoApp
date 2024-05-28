namespace MotoApp.Data;

using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

public class MotoAppDbContext : DbContext
{
    public DbSet<Employee> Employes =>  Set<Employee>();
        

    public DbSet<BusinesPartner> BusinesPartner => Set<BusinesPartner>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}


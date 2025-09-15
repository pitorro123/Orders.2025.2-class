using Microsoft.EntityFrameworkCore;
using Employee.Shared.Entities;

namespace Employee.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee.Shared.Entities.Employee> Employess { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee.Shared.Entities.Employee>().HasIndex(x => x.Id).IsUnique();
        {
        }
    }
}
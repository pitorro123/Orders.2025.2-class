using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Shared.Entities.Employee> Employess { get; set; }
    public object Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Shared.Entities.Employee>().Property(x => x.Savary).HasPrecision(18, 2);
        {
        }
    }
}
using Employee.Backend.Data;

namespace Employee.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckEmployeesAsync();
    }

    private async Task CheckEmployeesAsync()
    {
        if (!_context.Employess.Any())
        {
            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Fernando",
                LastName = "Garcia",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Savary = new Random().Next(1100000, 10000001)
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Ana Marina",
                LastName = "Giraldo",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Savary = 2500000.00m
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Esteban",
                LastName = "Vargas",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Savary = new Random().Next(1100000, 10000001)
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Sofia",
                LastName = "Garcia",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Savary = 1750000.00m
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Leonardo",
                LastName = "Yepes",
                IsActive = true,
                HireDate = new DateTime(2023, 2, 22, 04, 30, 0),
                Savary = new Random().Next(1100000, 10000001)
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Martinez",
                IsActive = true,
                HireDate = new DateTime(2022, 7, 14, 02, 32, 0),
                Savary = 3000000.00m
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Hilary",
                LastName = "Ospina",
                IsActive = false,
                HireDate = new DateTime(2021, 10, 05, 11, 12, 0),
                Savary = new Random().Next(1100000, 10000001)
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Velez",
                IsActive = true,
                HireDate = new DateTime(2020, 6, 25, 13, 42, 0),
                Savary = 2500000.00m
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Valentina",
                LastName = "Lopez",
                IsActive = false,
                HireDate = new DateTime(2022, 4, 12, 14, 36, 0),
                Savary = 1250000.00m
            });

            _context.Employess.Add(new Shared.Entities.Employee
            {
                FirstName = "Jesica",
                LastName = "Fernandez",
                IsActive = true,
                HireDate = new DateTime(2021, 5, 22, 15, 37, 0),
                Savary = new Random().Next(1100000, 10000001)
            });
            await _context.SaveChangesAsync();
        }
    }
}
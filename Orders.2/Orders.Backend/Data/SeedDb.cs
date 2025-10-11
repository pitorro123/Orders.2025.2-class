using Microsoft.EntityFrameworkCore;
using Orders.Share.Entities;

// un alimentador a la base de datos me va a garantizar un minimo de registros y siempre me va garantizar que hay
// una base de datos creada
//el alimetador  es una obligacion con usuarios y roles
//tenemos la api abierta y cuando le coloque la llave a la puerta de entrada yo no puedo cerrar sin antes tener la llave
//yo no puedo cerrar la puerta si no tengo la llave vamos a necesitar almenos unos roles y unos usuarios
//para que el administrador pueda entrar y crear los demas usuarios
namespace Orders.Backend.Data;

public class SeedDb
{
    // este readonly es para que no se pueda cambiar la referencia de este campo
    private readonly DataContext _context;

    // si yo quiero que esta inyeccion dure todo el ciclo de vida de la aplicacion vamos a crear un campo readonly
    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        //que mi programa siempre que arranque inicie por aca , lo que hace es que si no existe la bas de de datos la crea y si tiene migraciones
        // pendientes las crea y si no tiene migraciones pendientes no hace nada

        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesFullAsync();
        // estos 2 metodos es para que garantice que yo tengo paises y tengo categorias
        await CheckCountriesAsync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCountriesFullAsync()
    {// si (!)=> no hay paises metame estos paises
        if (!_context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data/CountriesStatesCities.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckCountriesAsync()
    {// si (!)=> no hay paises metame estos paises
        if (!_context.Countries.Any())
        {
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCategoriesAsync()
    {// si (!)=> no hay categorias metame estas categorias
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Apple" });
            _context.Categories.Add(new Category { Name = "Autos" });
            _context.Categories.Add(new Category { Name = "Belleza" });
            _context.Categories.Add(new Category { Name = "Calzado" });
            _context.Categories.Add(new Category { Name = "Comida" });
            _context.Categories.Add(new Category { Name = "Cosmeticos" });
            _context.Categories.Add(new Category { Name = "Deportes" });
            _context.Categories.Add(new Category { Name = "Erótica" });
            _context.Categories.Add(new Category { Name = "Ferreteria" });
            _context.Categories.Add(new Category { Name = "Gamer" });
            _context.Categories.Add(new Category { Name = "Hogar" });
            _context.Categories.Add(new Category { Name = "Jardín" });
            _context.Categories.Add(new Category { Name = "Jugetes" });
            _context.Categories.Add(new Category { Name = "Lenceria" });
            _context.Categories.Add(new Category { Name = "Mascotas" });
            _context.Categories.Add(new Category { Name = "Nutrición" });
            _context.Categories.Add(new Category { Name = "Ropa" });
            _context.Categories.Add(new Category { Name = "Tecnología" });
            await _context.SaveChangesAsync();
        }
    }
}
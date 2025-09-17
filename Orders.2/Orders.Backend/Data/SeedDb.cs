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
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country { Name = "Colombia" });
            _context.Countries.Add(new Country { Name = "Estados Unidos" });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Calzado" });
            _context.Categories.Add(new Category { Name = "Tecnología" });
        }

        await _context.SaveChangesAsync();
    }
}
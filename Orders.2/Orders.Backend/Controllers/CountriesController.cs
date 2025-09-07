using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Share.Entities;

namespace Orders.Backend.Controllers
{
    /// para que sirve este controlador? para manejar las peticiones relacionadas con los paises
    /// ya que ruta va a responder? a la ruta api/countries uqe es la ruta que va a manejar este controlador
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        //inyectamos el datacontext para poder acceder a la base de datos
        private readonly DataContext _context;

        //Metodo publico que tiene el mismo nombre de la clase
        //para inyectar, resulta que los constructores son la nalga de las clases porque por las nalgas les metemos la inyeccion
        //de dependencias y por las nalgas les metemos los parametros
        //
        public CountriesController(DataContext context)
        {
            //inyectamos el datacontext
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //Que hace return Ok(await _context.Countries.ToListAsync()); obtiene todos los paises de la base de datos y los devuelve
            //entonces este metodo obtiene todos los paises de la base de datos y los devuelve
            return Ok(await _context.Countries.ToListAsync());
        }

        //metodo para obtener todos los paises
        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            //Que _context.Countries.Add(country); hace? agrega un pais a la base de datos
            // y que hace await _context.SaveChangesAsync(); guarda los cambios en la base de datos
            // y que hace return Ok(country); devuelve el pais que se acaba de agregar
            //entonces este metodo agrega un pais a la base de datos y devuelve el pais que se acaba de agregar
            // cuando dices agrega un pais y luego lo devuelve, lo que devuelve es el pais con el id que le asigno la base de datos
            // porque cuando yo creo un pais el id es 0 y cuando lo guardo en la base de datos el id se lo asigna la base de datos
            // y ese id es el que devuelve el metodo cual metodo? return Ok(country);
            // no comprendo bien la ultima parte, si el id lo asigna la base de datos, como es que el pais que devuelve tiene el id?
            //
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
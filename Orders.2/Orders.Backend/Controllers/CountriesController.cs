using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Share.Entities;

namespace Orders.Backend.Controllers
{
    ///Marca esta clase como un controlador de API (maneja requests HTTP y devuelve JSON).
    [ApiController]
    // Define la ruta base. "[controller]" se reemplaza por el nombre de la clase SIN "Controller".
    // Es decir, la ruta será "api/countries".
    [Route("api/[controller]")]
    public class CountriesController : GenericController<Country>
    {
        public CountriesController(IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
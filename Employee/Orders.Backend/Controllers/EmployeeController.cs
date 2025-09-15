using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

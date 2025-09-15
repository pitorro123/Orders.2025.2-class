using Employee.Backend.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Backend.Data;
using Employee.Shared.Entities;

namespace Taller1.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee.Shared.Entities.Employee>
{
    private readonly IGenericUnitOfWork<Employee.Shared.Entities.Employee> _unitOfWork;
    private readonly IEmployeesUnitOfWork _employeesUnitOfWork;

    public EmployeesController(IGenericUnitOfWork<Employee.Shared.Entities.Employee> unitOfWork, IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _employeesUnitOfWork = employeesUnitOfWork;
    }

    [HttpGet("{name}")]
    public virtual async Task<IActionResult> GetAsync(string name)
    {
        var action = await _employeesUnitOfWork.GetAsync(name);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }
}
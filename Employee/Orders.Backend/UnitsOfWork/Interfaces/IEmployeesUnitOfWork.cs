namespace Employee.Backend.UnitsOfWork.Interfaces;

public interface IEmployeesUnitOfWork
{
    Task<Shared.Responses1.ActionResponses<IEnumerable<Shared.Entities.Employee>>> GetAsync(string name);
}
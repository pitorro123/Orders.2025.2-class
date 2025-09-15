using Employee.Shared.Responses1;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<ActionResponses<IEnumerable<Shared.Entities.Employee>>> GetAsync(string name);
    }
}
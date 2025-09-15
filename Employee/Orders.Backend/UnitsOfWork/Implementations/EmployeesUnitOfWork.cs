using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Responses1;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : IEmployeesUnitOfWork
    {
        private readonly IEmployeesRepository _employeesRepository;

        //Reducing some logic, no heritage of GenericUnitOfWork
        public EmployeesUnitOfWork(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<ActionResponses<IEnumerable<Shared.Entities.Employee>>> GetAsync(string name) =>
        await _employeesRepository.GetAsync(name);
    }
}
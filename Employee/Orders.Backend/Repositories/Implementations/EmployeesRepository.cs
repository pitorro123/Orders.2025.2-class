using Employee.Backend.Data;
using Employee.Shared.Responses1;
using Microsoft.EntityFrameworkCore;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.Entities;

namespace Employee.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<Shared.Entities.Employee>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<ActionResponses<IEnumerable<Shared.Entities.Employee>>> GetAsync(string name) => new ActionResponses<IEnumerable<Shared.Entities.Employee>>
        {
            WasSuccess = true,
            Result = await _context.Set<Shared.Entities.Employee>().Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync()
        };
    }
}
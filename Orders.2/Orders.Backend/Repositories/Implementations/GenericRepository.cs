using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;

namespace Orders.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExeptionActionResponse(exception);
            }
        }

        private ActionResponse<T> ExeptionActionResponse(Exception exception)
        {
            throw new NotImplementedException();
        }

        private ActionResponse<T> DbUpdateExceptionActionResponse()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<T>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<T>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
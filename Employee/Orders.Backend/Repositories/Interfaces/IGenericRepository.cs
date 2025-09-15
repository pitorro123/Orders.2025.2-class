namespace Employee.Backend.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<Shared.Responses1.ActionResponses<T>> GetAsync(int id);

    Task<Shared.Responses1.ActionResponses<IEnumerable<T>>> GetAsync();

    Task<Shared.Responses1.ActionResponses<T>> AddAsync(T entity);

    Task<Shared.Responses1.ActionResponses<T>> DeleteAsync(int id);

    Task<Shared.Responses1.ActionResponses<T>> UpdateAsync(T entity);
}
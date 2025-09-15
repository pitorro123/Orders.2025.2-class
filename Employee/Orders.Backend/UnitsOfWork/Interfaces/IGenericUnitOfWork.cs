namespace Employee.Backend.UnitsOfWork.Interfaces;

public interface IGenericUnitOfWork<T> where T : class
{
    Task<Shared.Responses1.ActionResponses<IEnumerable<T>>> GetAsync();

    Task<Shared.Responses1.ActionResponses<T>> AddAsync(T model);

    Task<Shared.Responses1.ActionResponses<T>> UpdateAsync(T model);

    Task<Shared.Responses1.ActionResponses<T>> DeleteAsync(int id);

    Task<Shared.Responses1.ActionResponses<T>> GetAsync(int id);
}
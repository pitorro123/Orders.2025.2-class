using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Responses1;

namespace Employee.Backend.UnitsOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<ActionResponses<T>> AddAsync(T entity) =>
    await _repository.AddAsync(entity);

    public virtual async Task<ActionResponses<T>> DeleteAsync(int id) =>
    await _repository.DeleteAsync(id);

    public virtual async Task<ActionResponses<T>> GetAsync(int id) =>
    await _repository.GetAsync(id);

    public virtual async Task<ActionResponses<IEnumerable<T>>> GetAsync() =>
    await _repository.GetAsync();

    public virtual async Task<ActionResponses<T>> UpdateAsync(T entity) =>
    await _repository.UpdateAsync(entity);
}
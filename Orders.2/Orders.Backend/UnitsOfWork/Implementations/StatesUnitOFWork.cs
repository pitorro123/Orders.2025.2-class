using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations;

//la unidad de trabajo de estados hereda de la unidad de trabajo generica con una implementacion especifica de estados
public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    //aca inyectamos el repositorio especifico de estados
    private readonly IStatesRepository _statesRepository;

    // aca le pasamos el repositorio generico se lo pasamos al padre y el repositorio especifico de estados se lo
    // asignamos a la variable local _statesRepository y trabajamos con el repositorio de estados para los metodos que
    // son especificos de estados y con el repositorio generico para los metodos genericos
    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _statesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _statesRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _statesRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);
}
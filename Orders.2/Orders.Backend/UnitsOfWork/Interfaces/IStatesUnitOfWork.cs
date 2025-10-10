using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitsOfWork.Interfaces;
// los metodos que tiene el unit of work son los mismos que tiene el repositorio
// por que tiene los mismos metodos que el repositorio ?
// por que el unit of work es una capa que esta por encima del repositorio y que hace cada uno ?
// el unit of work es una capa que se encarga de manejar las transacciones y el repositorio es una capa que se encarga de manejar la persistencia de los datos
// entonces el unit of work tiene los mismos metodos que el repositorio pero ademas tiene los metodos de transaccion

public interface IStatesUnitOfWork
{
    Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<State>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<State>>> GetAsync();
}
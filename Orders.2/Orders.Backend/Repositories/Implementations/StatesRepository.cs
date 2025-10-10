using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Helpers;
using Orders.Backend.Repositories.Interfaces;
using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.Repositories.Implementations;

// Repositorio de estados hereda del respsitorio generio con una implementacion especifica de estados ademas de eso
// impliementa la interface IStatesRepository que contiene los metodos especificos de estados
public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    //ahora el necesita un contructor porque el contructor de base necesita el contexto de datos
    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Include(x => x.Cities)
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }

    // hacemos un override del get y es te lo diferente es incluyame las ciudades
    // porque el get del repositorio generico no incluye las ciudades ya me va a traer los 124 municipios que tiene antioquia
    // y si yo quiero que me traiga las ciudades tengo que hacer un include de ciudades para que me las traiga tambien

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States
                  .Include(s => s.Cities)
                  .ToListAsync();
        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = states
        };
    }

    // lo mismo hacemos para el get por id que me traiga las ciudades
    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var state = await _context.States
                .Include(s => s.Cities)
                .FirstOrDefaultAsync(s => s.Id == id);
        if (state == null)
        {
            return new ActionResponse<State>
            {
                Message = "Estado no existe"
            };
        }
        return new ActionResponse<State>
        {
            WasSuccess = true,
            Result = state
        };
    }
}
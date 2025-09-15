using Employee.Backend.Data;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.Responses1;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public virtual async Task<ActionResponses<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponses<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception Exception)
        {
            return ExceptionActionResponse(Exception);
        }
    }

    public virtual async Task<ActionResponses<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);

        if (row == null)
        {
            return new ActionResponses<T>
            {
                Message = "Registro no encontrado."
            };
        }
        _entity.Remove(row);

        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponses<T>
            {
                WasSuccess = true
            };
        }
        catch
        {
            return new ActionResponses<T>
            {
                Message = "No se puede borrar ya que tiene registros relacionados."
            };
        }
    }

    public virtual async Task<ActionResponses<T>> GetAsync(int id)
    {
        var row = await _entity.FindAsync(id);

        if (row == null)
        {
            return new ActionResponses<T>
            {
                Message = "Registro no encontrado."
            };
        }
        return new ActionResponses<T>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponses<IEnumerable<T>>> GetAsync() => new ActionResponses<IEnumerable<T>>
    {
        WasSuccess = true,
        Result = await _entity.ToListAsync()
    };

    public virtual async Task<ActionResponses<T>> UpdateAsync(T entity)
    {
        _context.Update(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponses<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception Exception)
        {
            return ExceptionActionResponse(Exception);
        }
    }

    private ActionResponses<T> ExceptionActionResponse(Exception exception) => new ActionResponses<T>
    {
        Message = exception.Message
    };

    private ActionResponses<T> DbUpdateExceptionActionResponse() => new ActionResponses<T>
    {
        Message = "Ya existe el registro en la base de datos."
    };
}
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;
using Orders.Share.Responses;

namespace Orders.Backend.Repositories.Implementations
{
    //<T> indica que es una clase generica y puede trabajar con cualquier tipo de entidad

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // inyectamos el contexto de datos para poder acceder a la base de datos y realizar operaciones CRUD
        // el contexto de datos es una instancia de la clase DataContext que hereda de DbContext
        private readonly DataContext _context;

        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            // Agrega la entidad al contexto y guarda los cambios en la base de datos
            _context.Add(entity);
            //intentamos guardar los cambios en la base de datos
            try
            {
                //guardamos los cambios de manera asincrona
                await _context.SaveChangesAsync();
                //si todo sale bien devolvemos una respuesta exitosa con la entidad añadida
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

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }
            _entity.Remove(row);

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    Message = "No se pudo borrar porque tiene registros relacionados"
                };
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
        };

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
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

        private ActionResponse<T> ExeptionActionResponse(Exception exception) => new ActionResponse<T>
        {
            Message = exception.Message
        };

        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
        {
            Message = "No se puso crear, ya existe"
        };
    }
}
namespace Orders.Backend.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Define los métodos CRUD genéricos para cualquier entidad T
        // Cada método devuelve una tarea que resuelve en una ActionResponse que envuelve el resultado
        // la clase task es un generico y yo en el task le digo que voy a tener un metodo get con parametros
        // yo le digo que me devuelva un get de paises me veulvee un task de action response de paises
        //GetAsync recibe un id y devuelve una entidad T envuelta en una ActionResponse
        Task<ActionResponse<T>> GetAsync(int id);

        // GetAsync devuelve una lista de entidades T envuelta en una ActionResponse
        // GetAsync me devuelve un task de action response de una lista de paises o categorias
        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        // AddAsync recibe una entidad T y devuelve la entidad añadida envuelta en una ActionResponse
        Task<ActionResponse<T>> AddAsync(T entity);

        // DeleteAsync recibe un id y devuelve la entidad eliminada envuelta en una ActionResponse
        Task<ActionResponse<T>> DeleteAsync(int id);

        // UpdateAsync recibe una entidad T y devuelve la entidad actualizada envuelta en una ActionResponse
        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}
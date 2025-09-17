namespace Orders.Share.Responses
{
    public class ActionResponse<T>
    {
        // si la respuesta fue todo bien devolvemos un true en wasSuccessful si fallo de volvemos false
        public bool WasSuccess { get; set; }

        // si fallo le devolvemos un mensaje que fallo porque ya existe porque esta duplicado, etc
        public string? Message { get; set; }

        // me devuelve una propiedad que yo le mande si le mando un categories me da respuesta de categorias
        // si le mando un country me da respuesta de country
        public T? Result { get; set; }
    }
}
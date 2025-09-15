namespace Orders.Backend.Repositories.Interfaces
{
    public class ActionResponse<T> where T : class
    {
        public bool WasSuccess { get; internal set; }
        public string Message { get; internal set; }
        public T Result { get; internal set; }
    }
}
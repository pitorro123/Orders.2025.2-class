namespace Employee.Shared.Responses1;

public class ActionResponses<T>
{
    public bool WasSuccess { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }
}
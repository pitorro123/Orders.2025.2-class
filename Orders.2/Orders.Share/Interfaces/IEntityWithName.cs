namespace Orders.Share.Interfaces
{
    // todas las clases que implementen esta interfaz van a tener una propiedad Name
    public interface IEntityWithName
    {
        string Name { get; set; }
    }
}
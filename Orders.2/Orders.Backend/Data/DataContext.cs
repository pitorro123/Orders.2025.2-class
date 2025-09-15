using Microsoft.EntityFrameworkCore;
using Orders.Share.Entities;

namespace Orders.Backend.Data;

//DbContext? en el paquete Microsoft.EntityFrameworkCore permite consultar y guardar datos de la base de datos
public class DataContext : DbContext
{
    // DbContextOptions es una clase que contiene las opciones de configuracion para el DbContext
    // DbContextOptions es generico y le pasamos el tipo de clase que va a representar la base de datos
    // en este caso DataContext es la clase que representa la base de datos y DbContextOptions<DataContext> son las opciones de configuracion para esa base de datos
    // que opciones de configuracion puede tener? puede tener la cadena de conexion, el proveedor de base de datos, etc
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // DbSet es una clase que representa una tabla de la base de datos y permite consultar y guardar datos en esa tabla
    // DbSet es generico y le pasamos el tipo de clase que va a representar la tabla
    public DbSet<Category> Categories { get; set; }

    public DbSet<Country> Countries { get; set; }

    //OnModelCreating te permite configurar las entidades (tablas) y sus propiedades (columnas, índices, relaciones
    //ModelBuilder Su función: construir el modelo interno que conecta tus clases (entidades) con las tablas de la base de datos.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //llama al comportamiento por defecto de EF antes de agregar tus configuraciones personalizadas.
        base.OnModelCreating(modelBuilder);
        //que tiene un indicex y el indice esta en el campo name y aparte ese indice es unico estamos haciendo
        //validacoion por base de datos y si hacemos validaciones por base de datos no hay poder que valga
        modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
    }
}
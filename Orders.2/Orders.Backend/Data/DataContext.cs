using Microsoft.EntityFrameworkCore;
using Orders.Share.Entities;

namespace Orders.Backend.Data;

//Datacontext hereda de DbContext
public class DataContext : DbContext
{
    // creamos el constructor de la bade de datos yse lo pasamos a la super clase
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //cada tabla que yo vaya a mapear la voy a marcar conmo
    //una propiedad creamos una propiedad de tipo dbset es generico<>
    // las colecciones son en plural Contries
    public DbSet<Country> Countries { get; set; }

    //Quiero que no haya 2 paises ocn el mismo nombre, entonces vamos a crear un indice unico por nombre con el metodo
    // OnmodelCreating sobreescribimos el override onmodelcreating y se crea el objeto modelbuilder
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //que tiene un indicex y el indice esta en el campo name y aparte ese indice es unico estamos haciendo
        //validacoion por base de datos y si hacemos validaciones por base de datos no hay poder que valga
        //
        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
    }
}
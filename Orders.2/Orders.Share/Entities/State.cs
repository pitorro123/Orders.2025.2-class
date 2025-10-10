using Orders.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities;

public class State : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Estado")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    // con solo hacer esto entity dramework va deffinir la relacion de 1 a varios
    public int CountryId { get; set; }

    // ? con esto entity framework sabe que es una relacion de varios a 1
    public Country? Country { get; set; }

    // que un estado tiene varias ciudades el ? indica que puede ser nulo
    public ICollection<City>? Cities { get; set; }

    // esta propieedad de lectura se calculan en memoria no se guardan en la base de datos
    public int CitiesNumber => Cities == null ? 0 : Cities.Count;
}
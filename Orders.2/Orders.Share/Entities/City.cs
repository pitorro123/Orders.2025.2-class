using Orders.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities;

public class City : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Ciudad")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    // con solo hacer esto entity dramework va deffinir la relacion de 1 a varios
    public int StateId { get; set; }

    // ? con esto entity framework sabe que es una relacion de varios a 1
    public State? State { get; set; }
}
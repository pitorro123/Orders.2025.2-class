using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities;

public class Category
{
    public int Id { get; set; }

    [Display(Name = "Categoria")]
    [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;
}
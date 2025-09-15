using System.ComponentModel.DataAnnotations;

namespace Employee.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {O} es obligatorio")]
        [Display(Name = "Primer Nombre ")]
        [MaxLength(30, ErrorMessage = "Elcampo{O}no puede tener mas de {1} caracteres")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {O} es obligatorio")]
        [Display(Name = "Segundo Nombre")]
        [MaxLength(30, ErrorMessage = "Elcampo{O} no puede tener mas de {1} caracteres")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "FechaContratación")]
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1000000, double.MaxValue, ErrorMessage = "El salario debe ser mayor a {0}")]
        [Display(Name = "Salario")]
        public decimal Savary { get; set; }
    }
}
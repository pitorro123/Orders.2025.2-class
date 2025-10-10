using Orders.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities
{
    public class Country : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        // que un estado tiene varios paises el ? indica que puede ser nulo
        public ICollection<State>? States { get; set; }

        // esta propieedad de lectura se calculan en memoria no se guardan en la base de datos
        // si mi colecion de estados es =0 a nulo entonces devuelveme 0
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
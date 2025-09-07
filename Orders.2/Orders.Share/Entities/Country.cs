using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities
{
    public class Country
    {
        public int Id { get; set; }

        //la variable le cambiamos el nombre por Name a Pais
        [Display(Name = "Pais")]
        //Por defecto vieve con varchar el limite de varchar y le disminuimos los caracteres a 100
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //Entity framework cada vez que yo hago un cambio en la base de datos lo detecta y crea una migracion
        // Si yo cambio este 100 por 50 y creo una migracion me va a crear un script para modificar la tabla paises
        //migracion es tomele una foto al codigo y mire ese codigoque base de datos tengo y si hay alguna diferencia
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;
    }
}
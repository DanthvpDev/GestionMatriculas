using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Materias")]
    public class Materia
    {
        [Key]
        [Display(Name = "Código de la Materia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10, ErrorMessage = "La longitud máxima del campo es de 10 caracteres")]
        public required string Id_Materia { get; set; }

        [Display(Name = "Nombre de la Materia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(120, ErrorMessage = "La longitud máxima del campo es de 120 caracteres")]
        public required string Nombre_Materia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required int Creditos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required bool Borrado { get; set; } = false;

        public IEnumerable<MateriaCarrera> MateriasCarreras { get; set; } = new List<MateriaCarrera>();
    }
}

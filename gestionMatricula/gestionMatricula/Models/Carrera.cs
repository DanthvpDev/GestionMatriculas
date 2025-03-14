using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Carreras")]
    public class Carrera
    {
        [Key]
        [Display(Name = "Código de la Carrera")]
        public int Id_Carrera { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [Display(Name = "Nombre de la Carrera")]
        public required string Nombre_Carrera { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Total de Créditos")]
        public required int Total_Creditos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(14, ErrorMessage = "La longitud máxima del campo es de 14 caracteres")]
        [RegularExpression("^(Maestría|Licenciatura|Bachillerato|Diplomado)$", ErrorMessage = "El estado debe ser Maestría, Licenciatura, Bachillerato o Diplomado.")]
        public required string Grado { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(3, ErrorMessage = "La longitud máxima del campo es de 3 caracteres")]
        [Display(Name = "Estado")]
        [RegularExpression("^(Act|Ina)$", ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'.")]
        public required string Estado_C { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required bool Borrado { get; set; } = false;

        public IEnumerable<MateriaCarrera> MateriasCarreras { get; set; } = new List<MateriaCarrera>();
    }
}

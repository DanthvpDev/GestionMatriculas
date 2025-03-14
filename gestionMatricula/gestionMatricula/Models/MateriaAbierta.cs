using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Materias_Abiertas")]
    public class MateriaAbierta
    {
        [Key]
        [Column("id_MateriaAbierta")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Número de grupo")]
        public required int Grupo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Número de cupos")]
        public required int Cupos { get; set; } = 0;

        [Display(Name = "Número de matriculados")]
        [NotMapped]
        public int Cantidad_Matriculados { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required decimal Costo { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descuento")]
        public required decimal Descuento { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Periodo")]
        public required int id_Periodo { get; set; }
        public Periodo? Periodo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesor")]
        public required int id_Profesor { get; set; }
        public Profesor? Profesor { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Número de Aula")]
        public required int id_Aula { get; set; }
        public Aula? Aula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Materia")]
        public required int id_MateriaCarrera { get; set; }
        public MateriaCarrera? MateriaCarrera { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(3, ErrorMessage = "El máximo de letras es 3")]
        [RegularExpression("^ACT|INA|CER$", ErrorMessage = "El campo {0} solo puede ser ACT, INA o CER")]
        public required string Estado { get; set; }

        public IEnumerable<DetalleMatricula> DetallesMatriculas { get; set; } = new List<DetalleMatricula>();

    }
}

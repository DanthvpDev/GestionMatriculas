using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Periodo")]
    public class Periodo
    {
        [Key]
        [Column("id_Periodo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Número de periodo")]
        //Hacer constraint de que  periodo >= 1 && periodo <= 3
        public required int Num_Periodo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Año")]
        //Hacer constraint de que  anio >= AñoActual
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Inicio de Matrícula")]
        [DataType(DataType.Date)]
        public required DateTime FechaI_Matricula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Fin de Matrícula")]
        [DataType(DataType.Date)]
        public required DateTime FechaF_Matricula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Inicio de Matrícula Extraordinaria")]
        [DataType(DataType.Date)]
        public required DateTime FechaI_Extraordinaria { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Fin de Matrícula Extraordinaria")]
        [DataType(DataType.Date)]
        public required DateTime FechaF_Extraordinaria { get; set; }

        IEnumerable<MateriaAbierta> MateriasAbiertas { get; set; } = new List<MateriaAbierta>();
    }
}

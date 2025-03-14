using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Número de Recibo")]
        public int Num_Recibo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cédula del Estudiante")]
        [MaxLength(20, ErrorMessage = "El máximo de letras es 20")]
        public required string id_Estudiante { get; set; }
        public Estudiante? Estudiante { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Matrícula")]
        [DataType(DataType.Date)]
        public required DateTime Fecha_Matricula { get; set; }

        [Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Número de Periodo")]
        public required int id_Periodo { get; set; }
        public Periodo? Periodo { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Costo")]
        public required decimal Costo_Matricula { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required decimal Descuento { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^ANU|INA|ACT$", ErrorMessage = "El campo {0} solo puede ser ANU, INA o ACT")]
        [MaxLength(3, ErrorMessage = "El máximo de letras es 3")]
        public required string Estado { get; set; } = "ACT";

        public IEnumerable<DetalleMatricula> DetalleMatriculas { get; set; } = new List<DetalleMatricula>();


    }
}

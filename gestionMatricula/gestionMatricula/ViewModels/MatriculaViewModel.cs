using gestionMatricula.DTOs;
using System.ComponentModel.DataAnnotations;

namespace gestionMatricula.ViewModels
{
    public class MatriculaViewModel
    {
        //Matricula
        [Display(Name = "Número de Recibo")]
        public int? Num_Recibo { get; set; }
        [Display(Name = "Cédula del Estudiante")]
        [MaxLength(20, ErrorMessage = "El máximo de letras es 20")]
        public string? id_Estudiante { get; set; }
        public string? NombreEstudiante { get; set; }
        [Display(Name = "Fecha de Matrícula")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Matricula { get; set; }
        [Display(Name = "Número de Periodo")]
        public int id_Periodo { get; set; } = 0;
        [Display(Name = "Costo de Matricula")]
        public decimal Costo_Matricula { get; set; } = 0;
        [Display(Name = "Descuento en Matricula")]
        public decimal Descuento_Matricula { get; set; } = 0;

        [RegularExpression("^ANU|INA|ACT$", ErrorMessage = "El campo {0} solo puede ser ANU, INA o ACT")]
        public string Estado_Matricula { get; set; } = "";

        //Detalle Matricula
        public int? NotaFinal { get; set; }

        [RegularExpression("^DST|REP|RET|APR|ACT$", ErrorMessage = "El campo {0} solo puede ser DST, REP, RET o APR")]
        public string Estado_DM { get; set; } = "";

        [MaxLength(500, ErrorMessage = "El máximo de letras es 500")]
        public string? Observaciones { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "El atributo {0} es requerido")]
        public int id_MateriaAbierta { get; set; } = 0;

        //Información Extra
        public IEnumerable<MateriasDTO> MateriasAbiertas { get; set; } = new List<MateriasDTO>();
        public IEnumerable<MateriasDTO>? MateriasMatriculadas { get; set; } = new List<MateriasDTO>();
    }
}

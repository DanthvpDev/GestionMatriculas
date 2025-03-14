using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Detalles_Matricula")]
    public class DetalleMatricula
    {
        [Key, ForeignKey("Matricula")]
        [Display(Name = "Número de Recibo")]
        public int Num_Recibo { get; set; }
        public Matricula Matricula { get; set; }

        [Key, ForeignKey("MateriaAbierta")]
        [Display(Name = "Materia")]
        public int id_MateriaAbierta { get; set; }
        public MateriaAbierta MateriaAbierta { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nota Final")]
        public required decimal Nota_Final { get; set; } = 0;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(3, ErrorMessage = "El máximo de letras es 3")]
        [RegularExpression("^DST|REP|RET|APR|ACT$", ErrorMessage = "El campo {0} solo puede ser DST, REP, RET, APR o ACT")]
        public required string Estado { get; set; }

        [MaxLength(500, ErrorMessage = "El máximo de letras es 500")]
        public string? Observaciones { get; set; }
    }
}

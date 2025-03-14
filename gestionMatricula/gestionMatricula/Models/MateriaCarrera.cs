using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Materias_Carreras")]
    public class MateriaCarrera
    {
        [Column("Id_MateriaCarrera")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [ForeignKey(nameof(Materia))]
        public required string Id_Materia { get; set; }
        public required Materia Materia { get; set; }

        [ForeignKey(nameof(Carrera))]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required int Id_Carrera { get; set; }
        public required Carrera Carrera { get; set; }
        
        public string? Id_Requisito { get; set; }

        [ForeignKey("Id_Materia")]
        public Materia? Requisito { get; set; }
        public bool Borrado { get; set; } = false;

        public IEnumerable<MateriaAbierta> MateriasAbiertas { get; set; } = new List<MateriaAbierta>();
    }
}

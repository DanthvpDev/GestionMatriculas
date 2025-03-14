using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Distritos")]
    public class Distrito
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        [ForeignKey("Canton")]
        public int cantonID { get; set; }
        public Canton Canton { get; set; }

        public IEnumerable<Estudiante> Estudiantes { get; set; }    
    }
}

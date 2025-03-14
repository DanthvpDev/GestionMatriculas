using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Provincias")]
    public class Provincia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public IEnumerable<Canton> Cantones { get; set; } 
    }
}

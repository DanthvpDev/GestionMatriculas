using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Cantones")]
    public class Canton
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        [ForeignKey("Provincia")]
        public int provinciaID { get; set; }
        public Provincia Provincia { get; set; }
        public IEnumerable<Distrito> Distritos { get; set; }
    }
}

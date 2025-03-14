using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Aulas")]
    public class Aula
    {
        [Display(Name = "Id del Aula")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required int Capacidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        [Display(Name = "Tipo de Aula")]
        public required string Tipo { get; set; }

        IEnumerable<MateriaAbierta> MateriaAbiertas = new List<MateriaAbierta>();   
    }
}

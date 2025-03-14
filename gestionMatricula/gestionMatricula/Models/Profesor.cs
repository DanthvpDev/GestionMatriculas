using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Profesores")]
    public class Profesor
    {
        [Key]
        [Display(Name = "Código del Profesor")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Cod_Profesor { get; set; }

        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        public required string Id_Profesor { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(25, ErrorMessage = "La longitud máxima del campo es de 25 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        [Display(Name = "Primer Apellido")]
        public required string Apellido1_P { get; set; }

        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        [Display(Name = "Segundo Apellido")]
        public string? Apellido2_P { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(8, ErrorMessage = "La longitud máxima del campo es de 8 caracteres")]
        [RegularExpression(@"^\d{8}", ErrorMessage = "El teléfono debe tener 8 dígitos")]
        public required string Telefono_P { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(80, ErrorMessage = "Máximo de carácteres es de 25")]
        [EmailAddress(ErrorMessage = "Formato de correo incorrecto")]
        [Display(Name = "Correo Electrónico")]
        public required string Correo_E { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(3, ErrorMessage = "Máximo de carácteres es de 3")]
        [Display(Name = "Estado")]
        [RegularExpression("^(Act|Ina)$", ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'.")]
        public required string Estado_P { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required bool Borrado { get; set; } = false;

        [NotMapped]
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido1_P} {Apellido2_P}";
            }
        }

        IEnumerable<MateriaAbierta> MateriaAbiertas = new List<MateriaAbierta>();
    }
}

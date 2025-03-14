using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionMatricula.Models
{
    [Table("Estudiantes")]
    public class Estudiante
    {
        [Key]
        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        public required string Id_Estudiante { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(25, ErrorMessage = "La longitud máxima del campo es de 25 caracteres")]
        public required string  Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        [Display(Name = "Primer Apellido")]
        public required string Apellido1_E { get; set; }

        [MaxLength(20, ErrorMessage = "La longitud máxima del campo es de 20 caracteres")]
        [Display(Name = "Segundo Apellido")]
        public string? Apellido2_E { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(8, ErrorMessage = "La longitud máxima del campo es de 8 caracteres")]
        [RegularExpression(@"^\d{8}", ErrorMessage = "El teléfono debe tener 8 dígitos")]
        public required string Telefono1_E { get; set; }

        [MaxLength(8, ErrorMessage = "La longitud máxima del campo es de 8 caracteres")]
        [RegularExpression(@"^\d{8}", ErrorMessage = "El teléfono debe tener 8 dígitos")]
        public string? Telefono2_E { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "Máximo de carácteres es de 30")]
        [EmailAddress(ErrorMessage = "Formato de correo incorrecto")]
        [Display(Name = "Correo Electrónico")]
        public required string Correo_E { get; set; }

        [MaxLength(80, ErrorMessage = "La longitud máxima del campo es de 80 caracteres")]
        [Display(Name = "Otras Señas")]
        public string? Otras_Senias { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required int DistritoID { get; set; }
        public Distrito Distrito { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public  required DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Ingreso")]
        public required DateTime Fecha_Ingreso { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(3, ErrorMessage = "Máximo de carácteres es de 3")]
        [Display(Name = "Estado")]
        [RegularExpression("^(Act|Ina)$", ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'.")]
        public required string Estado_E { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required bool Borrado { get; set; } = false;

        [NotMapped]
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido1_E} {Apellido2_E}";
            }
        }

        IEnumerable<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}

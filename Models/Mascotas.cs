using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramación.Models
{
    public class Mascotas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la mascota no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especie de la mascota es obligatoria.")]
        [StringLength(50, ErrorMessage = "La especie no puede exceder los 50 caracteres.")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "La raza de la mascota es obligatoria.")]
        [StringLength(50, ErrorMessage = "La raza no puede exceder los 50 caracteres.")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento de la mascota es obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género de la mascota es obligatorio.")]
        public string Genero { get; set; } // Puedes utilizar enumeraciones (enum) para controlar los valores posibles

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string Observaciones { get; set; }

    }
}

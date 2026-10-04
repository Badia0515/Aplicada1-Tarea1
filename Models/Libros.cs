using System.ComponentModel.DataAnnotations;
namespace Tarea1.Models;
    public class Libros
    {
        [Key]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El campo Titulo no puede estar vacio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo Autor no puede estar vacio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El campo Anio no puede estar vacio")]
        public int Anio { get; set; }
    }

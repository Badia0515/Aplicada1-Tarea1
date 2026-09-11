using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models;

    public class Libros
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Anio { get; set;  }
        public string Genero { get; set; }
    }


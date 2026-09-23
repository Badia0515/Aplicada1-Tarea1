using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models;

    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public int IdEstudiante { get; set; }

        public int IdLibro { get; set; }

        public string FechaDePrestamo { get; set; }
    }


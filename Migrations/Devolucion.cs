using System.ComponentModel.DataAnnotations;
using Tarea1.Models;

namespace Tarea1.Migrations;

    public class Devolucion
    {
        [Key]
        public int IdDevolucion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe ser mayor que 1")]
        public int IdPrestamo{ get; set; }

        [Required(ErrorMessage = "Este campo Estudiante debe ser llenado")]
        public string Estudiante { get; set; }

        [Required(ErrorMessage = "Este campo Libro debe ser llenado")]
        public string FechaDevocion { get; set; }

        public Prestamo? Prestamo { get; set; }
    }


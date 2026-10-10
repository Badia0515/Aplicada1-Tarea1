using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea1.Models
{
    public class Devolucion
    {
        [Key]
        public int IdDevolucion { get; set; }


        [Required(ErrorMessage = "El ID del préstamo es requerido")]
        public int IdPrestamo { get; set; }


        [Required(ErrorMessage = "El nombre del libro es requerido")]
        public string Libro { get; set; } = string.Empty;


        public DateTime FechaDevolucion { get; set; }

        [ForeignKey(nameof(IdPrestamo))]
        [InverseProperty(nameof(Prestamo.devolucion))]
        public virtual Prestamo? prestamo { get; set; }
    }
}

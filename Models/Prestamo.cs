using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea1.Models { 

    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public int IdEstudiante { get; set; }

        public int IdLibro { get; set; }

        public DateTime FechaDePrestamo { get; set; }

        [InverseProperty(nameof(Devolucion.prestamo))]
        public virtual Devolucion? devolucion { get; set; }
    
    }
}


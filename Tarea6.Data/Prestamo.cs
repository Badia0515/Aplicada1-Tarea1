using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tarea6.Data
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public int IdEstudiante { get; set; }

        public int IdLibro { get; set; }

        public DateTime FechaDePrestamo { get; set; }


    }
}

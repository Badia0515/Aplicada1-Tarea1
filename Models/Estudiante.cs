using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models;

    public class Estudiante
    {

        [Key]
        public int EstudianteId { get; set; }

        public string Nombre { get; set; }

        public string Dirrecion { get; set; }

        public string Email { get; set; }

        public string FechaNacimiento { get; set; }
    }


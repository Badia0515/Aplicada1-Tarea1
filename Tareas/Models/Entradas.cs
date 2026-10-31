using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea1.Models
{
    public class Entradas
    {
        [Key]
        public int EntradaID { get; set; }

        [Required(ErrorMessage ="Debes de llenar este campo Fecha ")]
        public DateTime FechaDeEntrada { get; set; }

        [Required(ErrorMessage = "Debes de llenar este campo consepto")]
        public string Concepto { get; set; }

        public int Tota { get; set; }

        [InverseProperty(nameof(EntradasDetalles.Entradas))]
        public ICollection<EntradasDetalles> entradasDetalles { get; set; } = new List<EntradasDetalles>();
    }
}

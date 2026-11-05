using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Tarea1.Models
{
    public class EntradasDetalles
    {
        [Key]
        public int IdEntradaDetalle { get; set; }
        //El idEntrada no es  necesario por que ya esta identrada  
        public int IdEntrada { get; set; }

        public int IdLibros { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey(nameof(Entradas.EntradaID))]
        public virtual Entradas? Entradas { get; set; }

        [ForeignKey(nameof(IdLibros))]
        public virtual Libros? Libros { get; set; }
    }
}

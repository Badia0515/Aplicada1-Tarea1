
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Tarea1.Models;
namespace Tarea1.Context;

    public class DevolucionContext: DbContext
{
    public DevolucionContext(DbContextOptions<DevolucionContext> options) : base(options)
    {
    }
    public DbSet<Libros> Libros { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Prestamo> Prestamos { get; set; }

    public DbSet<Devolucion> devolucion { get; set; }

    public DbSet<Entradas> entradas { get; set; }

    public DbSet<EntradasDetalles> entradasDetalles { get; set; }

}








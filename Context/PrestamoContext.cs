
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Tarea1.Models;
namespace Tarea1.Context;

    public class PrestamoContext: DbContext
{
    public PrestamoContext(DbContextOptions<PrestamoContext> options) : base(options)
    {
    }
    public DbSet<Libros> Libros { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Prestamo> Prestamos { get; set; }

}








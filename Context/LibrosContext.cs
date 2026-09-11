
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Tarea1.Models;
namespace Tarea1.Context;

    public class LibrosContext: DbContext
{
    public LibrosContext(DbContextOptions<LibrosContext> options) : base(options)
    {
    }
    public DbSet<Libros> Libros { get; set; }
}





    


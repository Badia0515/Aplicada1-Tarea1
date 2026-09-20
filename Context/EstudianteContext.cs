
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Tarea1.Models;
namespace Tarea1.Context;

    public class EstudianteContext: DbContext
{
    public EstudianteContext(DbContextOptions<EstudianteContext> options) : base(options)
    {

    }

    public DbSet<Estudiantes> estudiantes { get; set; }
}





    


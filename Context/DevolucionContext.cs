using Microsoft.EntityFrameworkCore;
using Tarea1.Migrations;
using Tarea1.Models;

namespace Tarea1.Context
{
    public class DevolucionContext :DbContext
    {
        public DevolucionContext(DbContextOptions<DevolucionContext> options) : base(options)
        {
        }
        public DbSet<Devolucion> devolucion { get; set; }
        public DbSet<Prestamo> prestamo { get; set; }
    }
}

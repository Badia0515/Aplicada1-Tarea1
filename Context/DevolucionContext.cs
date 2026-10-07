using Microsoft.EntityFrameworkCore;
using Tarea1.Migrations;

namespace Tarea1.Context
{
    public class DevolucionContext :DbContext
    {
        public DevolucionContext(DbContextOptions<DevolucionContext> options) : base(options)
        {
        }
        public DbSet<Devolucion> devolucion { get; set; }
    }
}

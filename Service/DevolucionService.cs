using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Migrations;

namespace Tarea1.Service
{
    public class DevolucionService(IDbContextFactory<DevolucionContext> contextFactory) : IService<Devolucion, int>
    {
        public async Task<Devolucion?> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.FirstOrDefaultAsync(D => D.IdDevolucion == id);
        }

        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.AnyAsync(D => D.IdDevolucion == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.Where(D => D.IdDevolucion == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Devolucion>> GetList(Expression<Func<Devolucion, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Devolucion entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var ExistePrestamo = await context.prestamo.AnyAsync(P => P.IdPrestamo == entidad.IdPrestamo);
            if (!ExistePrestamo)
            {
                return false;
            }
            context.devolucion.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Editar(Devolucion entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.devolucion.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Devolucion entidad)
        {
            if (!await Existe(entidad.IdDevolucion))
            {
                return await Insertar(entidad);
            }
            else
            {
                return await Editar(entidad);
            }
        }
    }
}

using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Models;

namespace Tarea1.Service
{
    public class DevolucionService(IDbContextFactory<DevolucionContext> contextFactory) : IServiceResult<Devolucion, int>
    {
        public async Task<Result<Devolucion?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.FirstOrDefaultAsync(D => D.IdDevolucion == id);
        }

        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.AnyAsync(D => D.IdDevolucion == id);
        }

        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var Eliminar = await context.devolucion.Where(D => D.IdDevolucion == id).ExecuteDeleteAsync() > 0;
            return Result.Success(Eliminar);
        }

        public async Task<Result<List<Devolucion>>> GetList(Expression<Func<Devolucion, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.devolucion.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Devolucion devolucion)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var ExistePrestamo = await context.Prestamos.AnyAsync(P => P.IdPrestamo == devolucion.IdPrestamo);
            if (!ExistePrestamo)
            {
                return false;
            }
            context.devolucion.Add(devolucion);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Editar(Devolucion devolucion)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.devolucion.Update(devolucion);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Result> Guardar(Devolucion devolucion)
        {
            bool Guardado;
            if (!await Existe(devolucion.IdDevolucion))
            {
                Guardado = await Insertar(devolucion);
            }
            else
            {
                Guardado = await Editar(devolucion);
            }
            return Result.Success(Guardado);
        }
    }
}

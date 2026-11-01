using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea6.Data;

namespace Tarea6.Services
{
    public class PrestamoService(IDbContextFactory<ContextBD> contextFactory) : IServiceResult<Prestamo, int>
    {
        public async Task<Result<Prestamo?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }
        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.AnyAsync(p => p.IdPrestamo == id);
        }

        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var Eliminar = await context.Prestamos.Where(p => p.IdPrestamo == id).ExecuteDeleteAsync() > 0;
            return Result.Success(Eliminar);    
        }

        public async Task<Result<List<Prestamo>>> GetList(Expression<Func<Prestamo, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Prestamo entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Prestamos.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Editar(Prestamo entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Prestamos.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Result> Guardar(Prestamo entidad)
        {
            bool Guardando;
            if (!await Existe(entidad.IdPrestamo))
            {
                Guardando = await Insertar(entidad);
            }
            else
            {
                Guardando = await Editar(entidad);
            }
            return Result.Success(Guardando);
        }
    }
}

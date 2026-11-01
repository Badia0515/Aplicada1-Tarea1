using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea6.Data;

namespace Tarea6.Services
{
    public class LibrosService(IDbContextFactory<ContextBD> contextFactory) : IServiceResult<Libros, int>
    {
        public async Task<Result<Libros?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Libros.FirstOrDefaultAsync(L => L.IdLibro == id);
        }
        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Libros.AnyAsync(E => E.IdLibro == id);
        }

        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var Eliminar = await context.Libros.Where(D => D.IdLibro == id).ExecuteDeleteAsync() > 0;
            return Result.Success(Eliminar);
        }

        public async Task<Result<List<Libros>>> GetList(Expression<Func<Libros, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Libros.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Libros entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Libros.Add(entidad);
            return await context.SaveChangesAsync()>0;
        }
        public async Task<bool> Editar(Libros entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Libros.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Result> Guardar(Libros entidad)
        {
            bool Guardando;
            if(!await Existe(entidad.IdLibro))
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

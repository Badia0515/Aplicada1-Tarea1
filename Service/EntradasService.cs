using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Models;

namespace Tarea1.Service
{
    public class EntradasService(IDbContextFactory<DevolucionContext> contextFactory) : IServiceResult<Entradas, int>
    {
        public async Task<Result> Guardar(Entradas entidad)
        {
            bool Guardado;
            if(!await Existe(entidad.EntradaID))
            {
                Guardado= await Insertar(entidad);
            }
            else
            {
                Guardado = await Editar(entidad);
            }
            return Result.Success(Guardado);
        }
        public async Task<Result<Entradas?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.entradas.FirstOrDefaultAsync(E => E.EntradaID == id);
        }
        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.entradas.AnyAsync(E => E.EntradaID == id);
        }

        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var Eliminar = await context.entradas.Where(E => E.EntradaID == id).ExecuteDeleteAsync();
            return Result.Success(Eliminar);
            
        }

        public async Task<Result<List<Entradas>>> GetList(Expression<Func<Entradas, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.entradas.Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> Insertar(Entradas entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.entradas.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(Entradas entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.entradas.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        
    }
}

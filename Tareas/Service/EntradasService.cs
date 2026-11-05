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
            var Entradas = await context.entradas.Include(E => E.entradasDetalles).FirstOrDefaultAsync(E => E.EntradaID == id);
            if(Entradas == null)
            {
                return Result.Success(false);
            }
            await AfectarCantidad(Entradas.entradasDetalles.ToArray(), TipoOperacion.Resta);
            context.entradasDetalles.RemoveRange(Entradas.entradasDetalles);
            context.entradas.Remove(Entradas);
            var Cantidad = await context.SaveChangesAsync();
            return Result.Success(Cantidad > 0);

        }

        public async Task<Result<List<Entradas>>> GetList(Expression<Func<Entradas, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.entradas.Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> Insertar(Entradas entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            await AfectarCantidad(entidad.entradasDetalles.ToArray(), TipoOperacion.Suma);
            context.entradas.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task AfectarCantidad(EntradasDetalles[] detalles , TipoOperacion tipooperacion)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            foreach(var Detalle in detalles)
            {
                var libros = await context.Libros.FirstOrDefaultAsync(L => L.IdLibro == Detalle.IdLibros);
                if(libros != null) {

                    if (tipooperacion == TipoOperacion.Suma)
                    {
                        libros.LibroCantidad += Detalle.Cantidad;
                    }
                    else
                    {
                        libros.LibroCantidad -= Detalle.Cantidad;
                    }
                }

            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> Editar(Entradas entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.entradas.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public enum TipoOperacion
        {
            Suma,Resta
        }

        
    }
}

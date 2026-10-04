using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tarea1.Context;
using Tarea1.Models;

namespace Tarea1.Service
{
    public class PrestamoService(IDbContextFactory<PrestamoContext> contextFactory) : IService<Prestamo, int>
    {
        public async Task<Prestamo?> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.FirstOrDefaultAsync(L => L.IdPrestamo == id);
        }

        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.AnyAsync(L => L.IdPrestamo == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Prestamos.Where(L => L.IdPrestamo == id).ExecuteDeleteAsync()>0;
        }

        public async Task<List<Prestamo>> GetList(Expression<Func<Prestamo, bool>> criterio)
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
        public async Task<bool> Guardar(Prestamo entidad)
        {
            if(!await Existe(entidad.IdPrestamo))
            {
                return await Insertar(entidad);
            }
            else
            {
                return await Editar(entidad);

            }
           
        }
        public async Task<bool> Editar(Prestamo entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Prestamos.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }
    }

}

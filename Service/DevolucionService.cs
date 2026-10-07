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
            return await context.Devoluciones
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Devolucion>> GetList(Expression<Func<Devolucion, bool>> criterio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(Devolucion entidad)
        {
            throw new NotImplementedException();
        }
    }
}

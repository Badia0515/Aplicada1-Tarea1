using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Models;
namespace Tarea1.Service
{
    public class EstudianteService(IDbContextFactory<Context.PrestamoContext> contextFactory) : IService<Estudiante, int>
    {
        public async Task<Estudiante?> Buscar(int EstudianteId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.FirstOrDefaultAsync(L => L.EstudianteId == EstudianteId);
        }

        public async Task<bool> Eliminar(int EstudianteId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.Where(L => L.EstudianteId == EstudianteId).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Estudiante>> GetList(Expression<Func<Estudiante, bool>> Estudiante)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.Where(Estudiante).AsNoTracking().ToListAsync();
        }

        public async Task<bool> Guardar(Estudiante estudiante)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Estudiantes.Add(estudiante);
            return await context.SaveChangesAsync() > 0;

        }

        public async Task<bool> Editar(Estudiante estudiante)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Estudiantes.Update(estudiante);
            return await context.SaveChangesAsync() > 0;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Tarea6.Data;

namespace Tarea6.Services
{
    public class EstudianteService(IDbContextFactory<ContextBD> contextFactory) : IServiceResult<Estudiante, int>
    {
        public async Task<Result<Estudiante?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.FirstOrDefaultAsync(E => E.EstudianteId == id);
        }
        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.AnyAsync(E => E.EstudianteId == id);
        }

        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var Eliminar = await context.Estudiantes.Where(D => D.EstudianteId == id).ExecuteDeleteAsync() > 0;
            return Result.Success(Eliminar);

        }

        public async Task<Result<List<Estudiante>>> GetList(Expression<Func<Estudiante, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Estudiante entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Estudiantes.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Editar(Estudiante entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.Estudiantes.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Result> Guardar(Estudiante entidad)
        {
            bool Guardando;
            if(!await Existe(entidad.EstudianteId))
            {
               Guardando= await Insertar(entidad);
            }
            else
            {
                Guardando = await Editar(entidad);
            }
            return Result.Success(Guardando);
        }
    }
}

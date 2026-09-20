using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Models;
using Aplicada1.Core;
using System.Linq.Expressions;
namespace Tarea1.Service;

public class EstudianteService(IDbContextFactory<EstudianteContext> contextFactory) : IService<Estudiantes, int>
{

    public async Task<Estudiantes?> Buscar(int id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.estudiantes.FirstOrDefaultAsync(L => L.EstudianteId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.estudiantes.Where(L => L.EstudianteId == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Estudiantes>> GetList(Expression<Func<Estudiantes, bool>> Estudiante)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.estudiantes.Where(Estudiante).AsNoTracking().ToListAsync();
    }

    public async Task<bool> Guardar(Estudiantes estudiante)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.estudiantes.Add(estudiante);
        return await context.SaveChangesAsync() > 0;

    }

    public async Task<bool> Editar(Estudiantes estudiante)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.estudiantes.Update(estudiante);
        return await context.SaveChangesAsync() > 0;

    }



}



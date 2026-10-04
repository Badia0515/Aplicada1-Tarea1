using Microsoft.EntityFrameworkCore;
using Tarea1.Context;
using Tarea1.Models;
using Aplicada1.Core;
using System.Linq.Expressions;
namespace Tarea1.Service;

public class LibrosService(IDbContextFactory<Context.PrestamoContext> contextFactory) : IService<Libros, int>
{

    public async Task<bool> Insetar(Libros libro)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.Libros.Add(libro);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Libros libro)
    {
        if(!await Existe(libro.IdLibro))
        {
            return await Insetar(libro);
        }
        else
        {
            return await Editar(libro);
        }
        
    }

    public async Task<Libros?> Buscar(int Libroid)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Libros.FirstOrDefaultAsync(L => L.IdLibro == Libroid);
    }
    public async Task<bool> Existe(int IdLibro)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Libros.AnyAsync(L => L.IdLibro == IdLibro);
    }

    public async Task<bool> Eliminar(int IdLibro)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Libros.Where(L => L.IdLibro == IdLibro).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Libros>> GetList(Expression<Func<Libros, bool>> Lista)
    {
       await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Libros.Where(Lista).AsNoTracking().ToListAsync();
    }
    
    public async Task<bool> Editar(Libros libro)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.Libros.Update(libro);
        return await context.SaveChangesAsync() > 0;
    }
}

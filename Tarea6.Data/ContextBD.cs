using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tarea6.Data;

public partial class ContextBD : DbContext
{
    public ContextBD(DbContextOptions<ContextBD> options)
        : base(options)
    {
    }
    public virtual DbSet<Estudiante> Estudiantes { get; set; }
    public virtual DbSet<Libros> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

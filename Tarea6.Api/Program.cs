using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Tarea6.Data;
using Tarea6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContextFactory<ContextBD>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddTransient<EstudianteService>();
builder.Services.AddTransient<LibrosService>();
builder.Services.AddTransient<PrestamoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

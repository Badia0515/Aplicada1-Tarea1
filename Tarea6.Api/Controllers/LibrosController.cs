using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea6.Data;
using Tarea6.Services;

namespace Tarea6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController(LibrosService librosService): ControllerBase
    {

        // GET: api/Libros
        [HttpGet]
        public async Task<List<Libros>> GetLibros()
        {
            var Result = await librosService.GetList(E => true);
            return Result.Value;
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<Libros> GetLibros(int id)
        {
            var Estudiante = await librosService.Buscar(id);
            return Estudiante.Value;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutLibros(int id, Libros libros)
        {
            
        }

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CreatedResult> PostLibros(Libros libros)
        {
            var Result = await librosService.Guardar(libros);
            return Created();
        }

            // DELETE: api/Libros/5
            [HttpDelete("{id}")]
        public async Task DeleteLibros(int id)
        {
           
        }
    }
}

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
    public class EstudiantesController(EstudianteService estudianteService) : ControllerBase
    {

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<List<Estudiante>> GetEstudiantes()
        {
            var Result = await estudianteService.GetList(E => true);
            return Result.Value;
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<Estudiante> GetEstudiante(int id)
        {
            var Estudiante = await estudianteService.Buscar(id);
            return Estudiante.Value;
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async void PutEstudiante(int id, Estudiante estudiante)
        {
           
        }

        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CreatedResult> PostEstudiante(Estudiante estudiante)
        {
            var Result = await estudianteService.Guardar(estudiante);
            return Created();
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async void DeleteEstudiante(int id)
        {
            
        }
    }
}

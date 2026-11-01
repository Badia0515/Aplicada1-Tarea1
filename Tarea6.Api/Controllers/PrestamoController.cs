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
    public class PrestamoController(PrestamoService prestamoService) : ControllerBase
    {
        

        // GET: api/Prestamo
        [HttpGet]
        public async Task<List<Prestamo>> GetPrestamos()
        {
            var Result = await prestamoService.GetList(P => true);
            return Result.Value;
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}")]
        public async Task<Prestamo> GetPrestamo(int id)
        {
            var Estudiante = await prestamoService.Buscar(id);
            return Estudiante.Value;
        }

        // PUT: api/Prestamo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutPrestamo(int id, Prestamo prestamo)
        {
            
        }

        // POST: api/Prestamo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CreatedResult> PostPrestamo(Prestamo prestamo)
        {
            var Result = await prestamoService.Guardar(prestamo);
            return Created();
        }

        // DELETE: api/Prestamo/5
        [HttpDelete("{id}")]
        public async Task DeletePrestamo(int id)
        {
           
        }

    }
}

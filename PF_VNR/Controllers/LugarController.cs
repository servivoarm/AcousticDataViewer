using Microsoft.AspNetCore.Mvc;
using PF_VNR.Data;
using PF_VNR.Models;
using Microsoft.EntityFrameworkCore;

namespace PF_VNR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LugarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lugares = await _context.Lugares.OrderBy(l => l.Nombre).ToListAsync();

            return Ok(lugares);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lugar = await _context.Lugares.FirstOrDefaultAsync(l => l.LugarId == id);

            if (lugar == null)
                return NotFound(new { message = "Lugar no encontrado." });

            return Ok(lugar);
        }

        [HttpPost]
        public async Task<IActionResult> CrearLugar([FromBody] Lugar model)
        {
            _context.Lugares.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.LugarId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarLugar(int id, [FromBody] Lugar model)
        {
            if (id != model.LugarId)
                return BadRequest(new { message = "ID no coincide." });

            _context.Lugares.Update(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarLugar(int id)
        {
            var lugar = await _context.Lugares.FindAsync(id);
            if (lugar == null)
                return NotFound(new { message = "Lugar no encontrado." });

            _context.Lugares.Remove(lugar);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Lugar eliminado correctamente." });
        }

    }
}

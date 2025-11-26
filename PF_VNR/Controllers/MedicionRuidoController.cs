using Microsoft.AspNetCore.Mvc;
using PF_VNR.Data;
using PF_VNR.Models;
using Microsoft.EntityFrameworkCore;

namespace PF_VNR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicionRuidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicionRuidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datos = await _context.MedicionesRuido.Include(m => m.Lugar).OrderByDescending(m => m.FechaHora).ToListAsync();

            return Ok(datos);
        }

        [HttpGet("por-lugar/{id:int}")]
        public async Task<IActionResult> GetByLugar(int id)
        {
            var datos = await _context.MedicionesRuido.Where(m => m.LugarId == id).OrderBy(m => m.FechaHora).ToListAsync();

            return Ok(datos);
        }
    }
}

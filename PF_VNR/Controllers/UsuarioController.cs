using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_VNR.Data;
using PF_VNR.Models;

namespace PF_VNR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u =>
                    u.NombreUsuario == request.Usuario &&
                    u.ContrasenaHash == request.Contrasena);


            if (usuario == null)
            {
                return new LoginResponse
                {
                    Exito = false,
                    Mensaje = "Usuario o contraseña incorrectos."
                };
            }

            return Ok(new LoginResponse
            {
                Exito = true,
                Mensaje = "Inicio de sesión correcto.",
                Usuario = usuario.NombreUsuario,
                Rol = usuario.Rol.Nombre
            });

        }
    }
}

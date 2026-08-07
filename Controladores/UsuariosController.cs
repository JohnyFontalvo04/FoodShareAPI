using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using FoodShareAPI.DTOs;
using System.Linq;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // ==========================================
        // GET: api/Usuarios
        // Requiere autenticación
        // ==========================================
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();

            var usuariosDto = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Telefono = u.Telefono,
                Direccion = u.Direccion,
                Rol = u.Rol,
                FechaRegistro = u.FechaRegistro,
                Activo = u.Activo
            });

            return Ok(usuariosDto);
        }

        // ==========================================
        // GET: api/Usuarios/1
        // Requiere autenticación
        // ==========================================
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> ObtenerUsuario(int id)
        {
            var usuario = await _usuarioService.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Direccion = usuario.Direccion,
                Rol = usuario.Rol,
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo
            };

            return Ok(usuarioDto);
        }

        // ==========================================
        // POST: api/Usuarios
        // Público (registro)
        // ==========================================
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            try
            {
                var nuevoUsuario = await _usuarioService.CrearAsync(usuario);

                return CreatedAtAction(
                    nameof(ObtenerUsuario),
                    new { id = nuevoUsuario.Id },
                    nuevoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ==========================================
        // PUT: api/Usuarios/1
        // Requiere autenticación
        // ==========================================
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            try
            {
                await _usuarioService.ActualizarAsync(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ==========================================
        // DELETE: api/Usuarios/1
        // Requiere autenticación
        // ==========================================
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                await _usuarioService.EliminarAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
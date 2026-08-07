using Microsoft.AspNetCore.Mvc;
using FoodShareAPI.DTOs;
using FoodShareAPI.Interfaces;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ============================
        // POST: api/Auth/login
        // Iniciar sesión
        // ============================
        [HttpPost("login")]
        public async Task<ActionResult<LoginRespuestaDto>> Login(LoginDto loginDto)
        {
            var usuario = await _authService.LoginAsync(loginDto);

            if (usuario == null)
            {
                return Unauthorized("Correo o contraseña incorrectos.");
            }

            return Ok(usuario);
        }
    }
}
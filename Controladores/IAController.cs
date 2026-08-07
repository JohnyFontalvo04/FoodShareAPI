using FoodShareAPI.DTOs;
using FoodShareAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAController : ControllerBase
    {
        private readonly IGroqService _groqService;

        public IAController(IGroqService groqService)
        {
            _groqService = groqService;
        }

        /// <summary>
        /// Analiza una donación mediante inteligencia artificial.
        /// </summary>
        [HttpPost("analizar")]
        public async Task<ActionResult<RespuestaIA>> AnalizarDonacion(
            [FromBody] AnalizarDonacionDto donacion)
        {
            try
            {
                var resultado =
                    await _groqService.AnalizarDonacionAsync(donacion);

                return Ok(resultado);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(
                    StatusCodes.Status502BadGateway,
                    new
                    {
                        mensaje = "No fue posible comunicarse con Groq.",
                        detalle = ex.Message
                    });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        mensaje = ex.Message
                    });
            }
        }
    }
}
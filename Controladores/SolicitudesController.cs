using Microsoft.AspNetCore.Mvc;
using FoodShareAPI.DTOs;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using System.Linq;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudService _solicitudService;

        public SolicitudesController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        // GET: api/Solicitudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudDto>>> ObtenerSolicitudes()
        {
            var solicitudes = await _solicitudService.ObtenerTodasAsync();

            var solicitudesDto = solicitudes.Select(s => new SolicitudDto
            {
                Id = s.Id,
                DonacionId = s.DonacionId,
                UsuarioId = s.UsuarioId,
                FechaSolicitud = s.FechaSolicitud,
                Estado = s.Estado
            });

            return Ok(solicitudesDto);
        }

        // GET: api/Solicitudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudDto>> ObtenerSolicitud(int id)
        {
            var solicitud = await _solicitudService.ObtenerPorIdAsync(id);

            if (solicitud == null)
            {
                return NotFound("Solicitud no encontrada.");
            }

            var solicitudDto = new SolicitudDto
            {
                Id = solicitud.Id,
                DonacionId = solicitud.DonacionId,
                UsuarioId = solicitud.UsuarioId,
                FechaSolicitud = solicitud.FechaSolicitud,
                Estado = solicitud.Estado
            };

            return Ok(solicitudDto);
        }

        // POST: api/Solicitudes
        [HttpPost]
        public async Task<ActionResult> CrearSolicitud(CrearSolicitudDto dto)
        {
            var solicitud = new Solicitud
            {
                DonacionId = dto.DonacionId,
                UsuarioId = dto.UsuarioId
            };

            var resultado = await _solicitudService.CrearAsync(solicitud);

            return CreatedAtAction(
                nameof(ObtenerSolicitud),
                new { id = resultado.Id },
                resultado);
        }

        // PUT: api/Solicitudes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSolicitud(int id, Solicitud solicitud)
        {
            if (id != solicitud.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            await _solicitudService.ActualizarAsync(solicitud);

            return NoContent();
        }

        // PUT: api/Solicitudes/5/aprobar
        [HttpPut("{id}/aprobar")]
        public async Task<IActionResult> AprobarSolicitud(int id)
        {
            try
            {
                await _solicitudService.AprobarAsync(id);

                return Ok("Solicitud aprobada correctamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Solicitudes/5/rechazar
        [HttpPut("{id}/rechazar")]
        public async Task<IActionResult> RechazarSolicitud(int id)
        {
            try
            {
                await _solicitudService.RechazarAsync(id);

                return Ok("Solicitud rechazada correctamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Solicitudes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSolicitud(int id)
        {
            await _solicitudService.EliminarAsync(id);

            return NoContent();
        }
    }
}
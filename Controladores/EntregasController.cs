using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FoodShareAPI.DTOs;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using System.Linq;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EntregasController : ControllerBase
    {
        private readonly IEntregaService _entregaService;

        public EntregasController(IEntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        // GET: api/Entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> ObtenerTodas()
        {
            var entregas = await _entregaService.ObtenerTodasAsync();

            var entregasDto = entregas.Select(e => new EntregaDto
            {
                Id = e.Id,
                SolicitudId = e.SolicitudId,
                FechaEntrega = e.FechaEntrega,
                EstadoEntrega = e.EstadoEntrega,
                Observaciones = e.Observaciones
            });

            return Ok(entregasDto);
        }

        // GET: api/Entregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntregaDto>> ObtenerPorId(int id)
        {
            var entrega = await _entregaService.ObtenerPorIdAsync(id);

            if (entrega == null)
            {
                return NotFound("Entrega no encontrada.");
            }

            var entregaDto = new EntregaDto
            {
                Id = entrega.Id,
                SolicitudId = entrega.SolicitudId,
                FechaEntrega = entrega.FechaEntrega,
                EstadoEntrega = entrega.EstadoEntrega,
                Observaciones = entrega.Observaciones
            };

            return Ok(entregaDto);
        }

        // POST: api/Entregas
        [HttpPost]
        public async Task<IActionResult> Crear(Entrega entrega)
        {
            var nuevaEntrega = await _entregaService.CrearAsync(entrega);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = nuevaEntrega.Id },
                nuevaEntrega);
        }

        // PUT: api/Entregas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Entrega entrega)
        {
            if (id != entrega.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            await _entregaService.ActualizarAsync(entrega);

            return NoContent();
        }

        // DELETE: api/Entregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _entregaService.EliminarAsync(id);

            return NoContent();
        }
    }
}
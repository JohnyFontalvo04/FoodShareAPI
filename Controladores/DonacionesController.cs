using Microsoft.AspNetCore.Mvc;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using FoodShareAPI.DTOs;
using System.Linq;

namespace FoodShareAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonacionesController : ControllerBase
    {
        private readonly IDonacionService _donacionService;

        public DonacionesController(IDonacionService donacionService)
        {
            _donacionService = donacionService;
        }

        // GET: api/Donaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonacionDto>>> ObtenerDonaciones()
        {
            var donaciones = await _donacionService.ObtenerTodasAsync();

            var donacionesDto = donaciones.Select(d => new DonacionDto
            {
                Id = d.Id,
                NombreAlimento = d.NombreAlimento,
                Cantidad = d.Cantidad,
                FechaVencimiento = d.FechaVencimiento,
                Descripcion = d.Descripcion,
                FechaDonacion = d.FechaDonacion,
                Disponible = d.Disponible,
                UsuarioId = d.UsuarioId
            });

            return Ok(donacionesDto);
        }

        // GET: api/Donaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonacionDto>> ObtenerDonacion(int id)
        {
            var donacion = await _donacionService.ObtenerPorIdAsync(id);

            if (donacion == null)
            {
                return NotFound("Donación no encontrada.");
            }

            var donacionDto = new DonacionDto
            {
                Id = donacion.Id,
                NombreAlimento = donacion.NombreAlimento,
                Cantidad = donacion.Cantidad,
                FechaVencimiento = donacion.FechaVencimiento,
                Descripcion = donacion.Descripcion,
                FechaDonacion = donacion.FechaDonacion,
                Disponible = donacion.Disponible,
                UsuarioId = donacion.UsuarioId
            };

            return Ok(donacionDto);
        }

        // POST: api/Donaciones
        [HttpPost]
        public async Task<ActionResult> CrearDonacion(CrearDonacionDto dto)
        {
            var donacion = new Donacion
            {
                NombreAlimento = dto.NombreAlimento,
                Cantidad = dto.Cantidad,
                FechaVencimiento = dto.FechaVencimiento,
                Descripcion = dto.Descripcion,
                UsuarioId = dto.UsuarioId
            };

            var resultado = await _donacionService.CrearAsync(donacion);

            return CreatedAtAction(
                nameof(ObtenerDonacion),
                new { id = resultado.Id },
                resultado);
        }

        // PUT: api/Donaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDonacion(int id, Donacion donacion)
        {
            if (id != donacion.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            await _donacionService.ActualizarAsync(donacion);

            return NoContent();
        }

        // DELETE: api/Donaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDonacion(int id)
        {
            await _donacionService.EliminarAsync(id);

            return NoContent();
        }
    }
}
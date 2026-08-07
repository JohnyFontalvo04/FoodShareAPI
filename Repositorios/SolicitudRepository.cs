using FoodShareAPI.Datos;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FoodShareAPI.Repositorios
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly FoodShareDbContext _context;

        public SolicitudRepository(FoodShareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Solicitud>> ObtenerTodasAsync()
        {
            return await _context.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Donacion)
                .ToListAsync();
        }

        public async Task<Solicitud?> ObtenerPorIdAsync(int id)
        {
            return await _context.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Donacion)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Solicitud> CrearAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task ActualizarAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
        }
    }
}
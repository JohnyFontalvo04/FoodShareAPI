using FoodShareAPI.Datos;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FoodShareAPI.Repositorios
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly FoodShareDbContext _context;

        public EntregaRepository(FoodShareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entrega>> ObtenerTodasAsync()
        {
            return await _context.Entregas
                .Include(e => e.Solicitud)
                .ToListAsync();
        }

        public async Task<Entrega?> ObtenerPorIdAsync(int id)
        {
            return await _context.Entregas
                .Include(e => e.Solicitud)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Entrega> CrearAsync(Entrega entrega)
        {
            _context.Entregas.Add(entrega);
            await _context.SaveChangesAsync();
            return entrega;
        }

        public async Task ActualizarAsync(Entrega entrega)
        {
            _context.Entregas.Update(entrega);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Entrega entrega)
        {
            _context.Entregas.Remove(entrega);
            await _context.SaveChangesAsync();
        }
    }
}
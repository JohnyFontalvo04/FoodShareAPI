using Microsoft.EntityFrameworkCore;
using FoodShareAPI.Datos;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Repositorios
{
    public class DonacionRepository : IDonacionRepository
    {
        private readonly FoodShareDbContext _context;

        public DonacionRepository(FoodShareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donacion>> ObtenerTodasAsync()
        {
            return await _context.Donaciones
                .Include(d => d.Usuario)
                .ToListAsync();
        }

        public async Task<Donacion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Donaciones
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Donacion> CrearAsync(Donacion donacion)
        {
            _context.Donaciones.Add(donacion);
            await _context.SaveChangesAsync();
            return donacion;
        }

        public async Task ActualizarAsync(Donacion donacion)
        {
            _context.Donaciones.Update(donacion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Donacion donacion)
        {
            _context.Donaciones.Remove(donacion);
            await _context.SaveChangesAsync();
        }
    }
}
using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Servicios
{
    public class DonacionService : IDonacionService
    {
        private readonly IDonacionRepository _donacionRepository;

        public DonacionService(IDonacionRepository donacionRepository)
        {
            _donacionRepository = donacionRepository;
        }

        public async Task<IEnumerable<Donacion>> ObtenerTodasAsync()
        {
            return await _donacionRepository.ObtenerTodasAsync();
        }

        public async Task<Donacion?> ObtenerPorIdAsync(int id)
        {
            return await _donacionRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Donacion> CrearAsync(Donacion donacion)
        {
            return await _donacionRepository.CrearAsync(donacion);
        }

        public async Task ActualizarAsync(Donacion donacion)
        {
            await _donacionRepository.ActualizarAsync(donacion);
        }

        public async Task EliminarAsync(int id)
        {
            var donacion = await _donacionRepository.ObtenerPorIdAsync(id);

            if (donacion == null)
            {
                throw new Exception("Donación no encontrada.");
            }

            await _donacionRepository.EliminarAsync(donacion);
        }
    }
}
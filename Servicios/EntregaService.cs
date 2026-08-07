using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Servicios
{
    public class EntregaService : IEntregaService
    {
        private readonly IEntregaRepository _entregaRepository;

        public EntregaService(IEntregaRepository entregaRepository)
        {
            _entregaRepository = entregaRepository;
        }

        public async Task<IEnumerable<Entrega>> ObtenerTodasAsync()
        {
            return await _entregaRepository.ObtenerTodasAsync();
        }

        public async Task<Entrega?> ObtenerPorIdAsync(int id)
        {
            return await _entregaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Entrega> CrearAsync(Entrega entrega)
        {
            return await _entregaRepository.CrearAsync(entrega);
        }

        public async Task ActualizarAsync(Entrega entrega)
        {
            await _entregaRepository.ActualizarAsync(entrega);
        }

        public async Task EliminarAsync(int id)
        {
            var entrega = await _entregaRepository.ObtenerPorIdAsync(id);

            if (entrega == null)
            {
                throw new Exception("Entrega no encontrada.");
            }

            await _entregaRepository.EliminarAsync(entrega);
        }
    }
}

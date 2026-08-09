using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Servicios
{
    public class EntregaService : IEntregaService
    {
        private readonly IEntregaRepository _entregaRepository;
        private readonly ISolicitudRepository _solicitudRepository;

        public EntregaService(
            IEntregaRepository entregaRepository,
            ISolicitudRepository solicitudRepository)
        {
            _entregaRepository = entregaRepository;
            _solicitudRepository = solicitudRepository;
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
            // Crear la entrega
            var nuevaEntrega = await _entregaRepository.CrearAsync(entrega);

            // Buscar la solicitud relacionada
            var solicitud = await _solicitudRepository
                .ObtenerPorIdAsync(entrega.SolicitudId);

            if (solicitud != null)
            {
                // Si la entrega fue realizada
                if (entrega.EstadoEntrega?.ToLower() == "entregada")
                {
                    // Cambiar estado de la solicitud
                    solicitud.Estado = "Entregada";

                    // Marcar la donación como no disponible
                    if (solicitud.Donacion != null)
                    {
                        solicitud.Donacion.Disponible = false;
                    }

                    // Guardar cambios
                    await _solicitudRepository.ActualizarAsync(solicitud);
                }
            }

            return nuevaEntrega;
        }

        public async Task ActualizarAsync(Entrega entrega)
        {
            await _entregaRepository.ActualizarAsync(entrega);

            // Buscar la solicitud relacionada
            var solicitud = await _solicitudRepository
                .ObtenerPorIdAsync(entrega.SolicitudId);

            if (solicitud != null)
            {
                if (entrega.EstadoEntrega?.ToLower() == "entregada")
                {
                    // Cambiar estado de la solicitud
                    solicitud.Estado = "Entregada";

                    // Marcar la donación como no disponible
                    if (solicitud.Donacion != null)
                    {
                        solicitud.Donacion.Disponible = false;
                    }

                    // Guardar cambios
                    await _solicitudRepository.ActualizarAsync(solicitud);
                }
            }
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

using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Servicios
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IDonacionRepository _donacionRepository;

        public SolicitudService(
            ISolicitudRepository solicitudRepository,
            IDonacionRepository donacionRepository)
        {
            _solicitudRepository = solicitudRepository;
            _donacionRepository = donacionRepository;
        }

        public async Task<IEnumerable<Solicitud>> ObtenerTodasAsync()
        {
            return await _solicitudRepository.ObtenerTodasAsync();
        }

        public async Task<Solicitud?> ObtenerPorIdAsync(int id)
        {
            return await _solicitudRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Solicitud> CrearAsync(Solicitud solicitud)
        {
            return await _solicitudRepository.CrearAsync(solicitud);
        }

        public async Task ActualizarAsync(Solicitud solicitud)
        {
            await _solicitudRepository.ActualizarAsync(solicitud);
        }

        public async Task EliminarAsync(int id)
        {
            var solicitud = await _solicitudRepository.ObtenerPorIdAsync(id);

            if (solicitud == null)
            {
                throw new Exception("Solicitud no encontrada.");
            }

            await _solicitudRepository.EliminarAsync(solicitud);
        }

        public async Task AprobarAsync(int id)
        {
            var solicitud = await _solicitudRepository.ObtenerPorIdAsync(id);

            if (solicitud == null)
            {
                throw new Exception("Solicitud no encontrada.");
            }

            var donacion = await _donacionRepository.ObtenerPorIdAsync(solicitud.DonacionId);

            if (donacion == null)
            {
                throw new Exception("Donación no encontrada.");
            }

            solicitud.Estado = "Aprobada";
            donacion.Disponible = false;

            await _solicitudRepository.ActualizarAsync(solicitud);
            await _donacionRepository.ActualizarAsync(donacion);
        }

        public async Task RechazarAsync(int id)
        {
            var solicitud = await _solicitudRepository.ObtenerPorIdAsync(id);

            if (solicitud == null)
            {
                throw new Exception("Solicitud no encontrada.");
            }

            solicitud.Estado = "Rechazada";

            await _solicitudRepository.ActualizarAsync(solicitud);
        }
    }
}
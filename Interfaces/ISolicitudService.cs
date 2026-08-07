using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface ISolicitudService
    {
        Task<IEnumerable<Solicitud>> ObtenerTodasAsync();

        Task<Solicitud?> ObtenerPorIdAsync(int id);

        Task<Solicitud> CrearAsync(Solicitud solicitud);

        Task ActualizarAsync(Solicitud solicitud);

        Task EliminarAsync(int id);

        Task AprobarAsync(int id);

        Task RechazarAsync(int id);
    }
}
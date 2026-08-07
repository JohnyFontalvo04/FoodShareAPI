using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<IEnumerable<Solicitud>> ObtenerTodasAsync();

        Task<Solicitud?> ObtenerPorIdAsync(int id);

        Task<Solicitud> CrearAsync(Solicitud solicitud);

        Task ActualizarAsync(Solicitud solicitud);

        Task EliminarAsync(Solicitud solicitud);
    }
}
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface IDonacionRepository
    {
        Task<IEnumerable<Donacion>> ObtenerTodasAsync();

        Task<Donacion?> ObtenerPorIdAsync(int id);

        Task<Donacion> CrearAsync(Donacion donacion);

        Task ActualizarAsync(Donacion donacion);

        Task EliminarAsync(Donacion donacion);
    }
}

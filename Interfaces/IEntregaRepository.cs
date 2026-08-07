using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface IEntregaRepository
    {
        Task<IEnumerable<Entrega>> ObtenerTodasAsync();

        Task<Entrega?> ObtenerPorIdAsync(int id);

        Task<Entrega> CrearAsync(Entrega entrega);

        Task ActualizarAsync(Entrega entrega);

        Task EliminarAsync(Entrega entrega);
    }
}
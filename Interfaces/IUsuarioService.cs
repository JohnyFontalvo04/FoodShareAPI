using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();

        Task<Usuario?> ObtenerPorIdAsync(int id);

        Task<Usuario> CrearAsync(Usuario usuario);

        Task ActualizarAsync(Usuario usuario);

        Task EliminarAsync(int id);
    }
}
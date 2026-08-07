using FoodShareAPI.Modelos;

namespace FoodShareAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();

        Task<Usuario?> ObtenerPorIdAsync(int id);

        Task<Usuario?> ObtenerPorCorreoAsync(string correo);

        Task<Usuario> CrearAsync(Usuario usuario);

        Task ActualizarAsync(Usuario usuario);

        Task EliminarAsync(Usuario usuario);
    }
}
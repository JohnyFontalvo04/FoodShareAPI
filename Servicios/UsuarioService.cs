using FoodShareAPI.Interfaces;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.ObtenerTodosAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Usuario> CrearAsync(Usuario usuario)
        {
            var existe = await _usuarioRepository.ObtenerPorCorreoAsync(usuario.Correo);

            if (existe != null)
            {
                throw new Exception("Ya existe un usuario con ese correo.");
            }

            // Encriptar contraseña
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);

            return await _usuarioRepository.CrearAsync(usuario);
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            await _usuarioRepository.ActualizarAsync(usuario);
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            await _usuarioRepository.EliminarAsync(usuario);
        }
    }
}
using FoodShareAPI.DTOs;

namespace FoodShareAPI.Interfaces
{
    public interface IAuthService
    {
        Task<LoginRespuestaDto?> LoginAsync(LoginDto loginDto);
    }
}
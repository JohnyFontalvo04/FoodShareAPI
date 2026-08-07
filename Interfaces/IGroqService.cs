using FoodShareAPI.DTOs;

namespace FoodShareAPI.Interfaces
{
    public interface IGroqService
    {
        Task<RespuestaIA> AnalizarDonacionAsync(
            AnalizarDonacionDto donacion);
    }
}
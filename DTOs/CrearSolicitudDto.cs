using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.DTOs
{
    public class CrearSolicitudDto
    {
        [Required]
        public int DonacionId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
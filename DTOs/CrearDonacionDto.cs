using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.DTOs
{
    public class CrearDonacionDto
    {
        [Required]
        public string NombreAlimento { get; set; } = string.Empty;

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public int UsuarioId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.DTOs
{
    public class AnalizarDonacionDto
    {
        [Required]
        public string NombreAlimento { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;
    }
}
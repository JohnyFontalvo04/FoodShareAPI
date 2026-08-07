using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.Modelos
{
    public class Entrega
    {
        public int Id { get; set; }

        [Required]
        public int SolicitudId { get; set; }

        public Solicitud? Solicitud { get; set; }

        public DateTime FechaEntrega { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string EstadoEntrega { get; set; } = "Entregada";

        [StringLength(300)]
        public string? Observaciones { get; set; }
    }
}
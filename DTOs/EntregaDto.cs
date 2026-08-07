namespace FoodShareAPI.DTOs
{
    public class EntregaDto
    {
        public int Id { get; set; }

        public int SolicitudId { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string EstadoEntrega { get; set; } = string.Empty;

        public string? Observaciones { get; set; }
    }
}
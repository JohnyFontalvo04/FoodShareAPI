namespace FoodShareAPI.DTOs
{
    public class SolicitudDto
    {
        public int Id { get; set; }

        public int DonacionId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public string Estado { get; set; } = string.Empty;
    }
}
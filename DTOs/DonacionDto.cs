namespace FoodShareAPI.DTOs
{
    public class DonacionDto
    {
        public int Id { get; set; }

        public string NombreAlimento { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaDonacion { get; set; }

        public bool Disponible { get; set; }

        public int UsuarioId { get; set; }
    }
}
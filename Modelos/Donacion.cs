using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.Modelos
{
    public class Donacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreAlimento { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000)]
        public int Cantidad { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaDonacion { get; set; } = DateTime.Now;

        public bool Disponible { get; set; } = true;

        // Clave foránea
        public int UsuarioId { get; set; }

        // Navegación
        public Usuario? Usuario { get; set; }

        // Relaciones
        public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
    }
}
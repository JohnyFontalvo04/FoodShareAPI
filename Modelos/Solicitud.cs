using System.ComponentModel.DataAnnotations;

namespace FoodShareAPI.Modelos
{
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DonacionId { get; set; }

        public Donacion? Donacion { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Pendiente";

        // Relaciones
        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
    }
}
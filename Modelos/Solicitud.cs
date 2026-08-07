using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodShareAPI.Modelos
{
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DonacionId { get; set; }

        [ForeignKey("DonacionId")]
        public Donacion? Donacion { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Required]
        public string Estado { get; set; } = "Pendiente";
    }
}
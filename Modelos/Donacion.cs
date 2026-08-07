using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodShareAPI.Modelos
{
    public class Donacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreAlimento { get; set; } = string.Empty;

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaDonacion { get; set; } = DateTime.Now;

        public bool Disponible { get; set; } = true;

        // Usuario que realiza la donación
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
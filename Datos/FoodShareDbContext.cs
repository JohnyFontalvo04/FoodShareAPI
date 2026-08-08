using Microsoft.EntityFrameworkCore;
using FoodShareAPI.Modelos;

namespace FoodShareAPI.Datos
{
    public class FoodShareDbContext : DbContext
    {
        public FoodShareDbContext(DbContextOptions<FoodShareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Donacion> Donaciones { get; set; }

        public DbSet<Solicitud> Solicitudes { get; set; }

        public DbSet<Entrega> Entregas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Usuario -> Donaciones
            modelBuilder.Entity<Donacion>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Donaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario -> Solicitudes
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.Solicitudes)
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Donación -> Solicitudes
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Donacion)
                .WithMany(d => d.Solicitudes)
                .HasForeignKey(s => s.DonacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud -> Entregas
            modelBuilder.Entity<Entrega>()
                .HasOne(e => e.Solicitud)
                .WithMany(s => s.Entregas)
                .HasForeignKey(e => e.SolicitudId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
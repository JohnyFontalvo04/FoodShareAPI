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

            modelBuilder.Entity<Donacion>()
                .HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Donacion)
                .WithMany()
                .HasForeignKey(s => s.DonacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FoodShareAPI.Datos;

namespace FoodShareAPI.Fabricas
{
    public class FoodShareDbContextFactory : IDesignTimeDbContextFactory<FoodShareDbContext>
    {
        public FoodShareDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FoodShareDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=FoodShareDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new FoodShareDbContext(optionsBuilder.Options);
        }
    }
}
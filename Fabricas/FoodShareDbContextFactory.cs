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

            optionsBuilder.UseSqlite("Data Source=FoodShareDB.db");

            return new FoodShareDbContext(optionsBuilder.Options);
        }
    }
}
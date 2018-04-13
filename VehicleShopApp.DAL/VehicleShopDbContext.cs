using Microsoft.EntityFrameworkCore;
using VehicleShopApp.Model;

namespace VehicleShopApp.DAL
{
    public class VehicleShopDbContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleShopDbContext(DbContextOptions<VehicleShopDbContext> options)
          :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(v => new { v.Guid });
        }

    }
}

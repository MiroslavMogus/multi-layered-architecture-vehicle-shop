using Microsoft.EntityFrameworkCore;
using VehicleShopApp.Model;

namespace VehicleShopApp.DAL
{
    public class VehicleShopDbContext : DbContext
    {
        public VehicleShopDbContext(DbContextOptions<VehicleShopDbContext> options)
          :base(options)
        {
        }
        public DbSet<VehicleMake> VehicleMakes { get; set; }      
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }          
        }
}

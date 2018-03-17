using Microsoft.EntityFrameworkCore;
using VehicleShop.Core;
using VehicleShop.Core.Models;

namespace VehicleShop.Persistence
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

using Microsoft.EntityFrameworkCore;
using VehicleShopApp.Model;

namespace VehicleShopApp.DAL
{
    public class VehicleShopDbContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }

        public VehicleShopDbContext(DbContextOptions<VehicleShopDbContext> options)
          :base(options)
        {
        }
        
        }
}

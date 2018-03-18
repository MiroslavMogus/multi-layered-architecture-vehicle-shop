using System.Threading.Tasks;
using VehicleShopApp.DAL;
using VehicleShopApp.Model;

namespace VehicleShopApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleShopDbContext context;
        public UnitOfWork(VehicleShopDbContext context)
        {
            this.context = context;
        }
        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }

}
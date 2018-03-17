using System.Threading.Tasks;
using VehicleShop.Core;

namespace VehicleShop.Persistence
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
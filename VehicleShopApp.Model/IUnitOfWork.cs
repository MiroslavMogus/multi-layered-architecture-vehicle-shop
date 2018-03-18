using System.Threading.Tasks;

namespace VehicleShopApp.Model
{
    public interface IUnitOfWork
    {
        Task Complete();
    }

}
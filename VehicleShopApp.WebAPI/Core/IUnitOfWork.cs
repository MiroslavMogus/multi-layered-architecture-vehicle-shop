using System.Threading.Tasks;

namespace VehicleShop.Core
{
    public interface IUnitOfWork
    {
        Task Complete();
    }

}
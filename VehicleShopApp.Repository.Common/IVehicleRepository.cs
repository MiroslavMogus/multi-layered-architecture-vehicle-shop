using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Resources;

namespace VehicleShopApp.Repository.Common
{
    public interface IVehicleRepository
    {
         Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
    }
}
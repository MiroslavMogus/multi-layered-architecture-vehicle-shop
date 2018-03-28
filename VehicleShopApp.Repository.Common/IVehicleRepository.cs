using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;
using VehicleShopApp.Resources;

namespace VehicleShopApp.Repository.Common
{
    public interface IVehicleRepository
    {
         Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
         Task<IEnumerable<VehicleResource>> GetVehicles();
         Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
    }
}
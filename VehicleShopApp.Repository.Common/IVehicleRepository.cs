using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;
using VehicleShopApp.Resources;

namespace VehicleShopApp.Repository.Common
{
    public interface IVehicleRepository
    {
        // Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
        IEnumerable<VehicleMakeResource> GetVehicleMakes();

        // Task<IEnumerable<VehicleResource>> GetVehicles();
        IEnumerable<VehicleResource> GetVehicles();
        
        // Task<Vehicle> 
        Vehicle GetVehicle(int id, bool includeRelated = true);
        Vehicle CreateVehicle(SaveVehicleResource vehicleResource);
    }
}

using System.Collections.Generic;
using VehicleShopApp.Model;
using VehicleShopApp.Resources;

namespace VehicleShopApp.Service.Common
{
    public interface IVehicleService
    {
        IEnumerable<VehicleResource> GetVehicles();
        IEnumerable<VehicleMakeResource> GetVehicleMakes();
        void CreateVehicle(SaveVehicleResource vehicleResource);
    }
}

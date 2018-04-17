using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;

namespace VehicleShopApp.Service.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleResource>> GetVehicles(ObjectQueryResource queryResource);
        Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
        Task<Vehicle> CreateVehicle(SaveVehicleResource vehicleResource);
        Task<SaveVehicleResource> EditVehicle(int id, SaveVehicleResource vehicleResource);
        //Task<SaveVehicleResource> DeleteVehicle(int id);
        Task<VehicleResource> GetVehicleResource(int id);
        Task<Vehicle> GetVehicle(int id);
        Task<int> GetVehiclesTotal();
        Task<Vehicle> DeleteVehicle(int id);
    }
}

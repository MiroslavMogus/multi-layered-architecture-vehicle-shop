using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;

namespace VehicleShopApp.Repository.Common
{
    public interface IVehicleRepository
    {
        object Vehicles { get; }

        Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
        Task<IEnumerable<Vehicle>> GetVehicles(ObjectQuery filter);

        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        Task<Vehicle> CreateVehicle(SaveVehicleResource vehicleResource);
        Task<Vehicle> EditVehicle(Vehicle vehicle, SaveVehicleResource vehicleResource);
        Task<SaveVehicleResource> MapVehicle(Vehicle vehicle);
        Task<int> GetVehiclesTotal();
    }
}
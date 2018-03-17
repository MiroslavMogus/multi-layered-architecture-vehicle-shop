using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShop.Controllers.Resources;

namespace VehicleShop.Core
{
    public interface IVehicleRepository
    {
         Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes();
    }
}
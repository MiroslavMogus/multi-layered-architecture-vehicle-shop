using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.DAL;
using VehicleShopApp.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VehicleShopApp.Model;

namespace VehicleShopApp.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleShopDbContext context;
        private readonly IMapper vmapper;

        public object Vehicles => throw new System.NotImplementedException();

        public VehicleRepository(VehicleShopDbContext context, IMapper vmapper)
        {
            this.context = context;
            this.vmapper = vmapper;
        }

        async Task<IEnumerable<VehicleResource>> IVehicleRepository.GetVehicles()
        {
            var vehicles = await context.Vehicles
            .Include(v => v.VehicleModel)
            .ThenInclude(m => m.VehicleMake)
            .ToListAsync();

            return vmapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);
        }

        IEnumerable<VehicleMakeResource> IVehicleRepository.GetVehicleMakes()
        {
            var vehiclemakes = context.VehicleMakes.Include(m => m.VehicleModels).ToList();

            return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
        }

        Vehicle IVehicleRepository.GetVehicle(int id, bool includeRelated)
        {
            return context.Vehicles.Find(id);
        }

        Vehicle IVehicleRepository.CreateVehicle(SaveVehicleResource vehicleResource)
        {
            var vehicle = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            return vehicle;
        }

        Vehicle IVehicleRepository.EditVehicle(Vehicle vehicle, SaveVehicleResource vehicleResource)
        {
            var result = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            return result;
        }

        public SaveVehicleResource MapVehicle(Vehicle vehicle)
        {
            var result = vmapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return result;
        }
    }
}
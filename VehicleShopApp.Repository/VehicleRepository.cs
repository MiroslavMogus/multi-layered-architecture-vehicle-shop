using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.DAL;
using VehicleShopApp.Resources;
using VehicleShopApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VehicleShopApp.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleShopDbContext context;
        private readonly IMapper vmapper;
        public VehicleRepository(VehicleShopDbContext context, IMapper vmapper)
        {
            this.context = context;
            this.vmapper = vmapper;
        }

        IEnumerable<VehicleResource> IVehicleRepository.GetVehicles()
        {
            var vehicles = context.Vehicles
            .Include(v => v.VehicleModel)
            .ThenInclude(m => m.VehicleMake)
            .ToList();

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

            //context.Vehicles.Add(vehicle);

            //await context.SaveChangesAsync();

            return vehicle;
        }
    }
}
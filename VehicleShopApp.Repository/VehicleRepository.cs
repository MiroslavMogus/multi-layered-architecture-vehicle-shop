using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.DAL;
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

        async Task<IEnumerable<Vehicle>> IVehicleRepository.GetVehicles(ObjectQuery vehicleQuery)
        {
            var query = context.Vehicles
            .Include(v => v.VehicleModel)
            .ThenInclude(m => m.VehicleMake)
            .AsQueryable();

            if (vehicleQuery.VehicleMakeId.HasValue)
                query = query.Where(v => v.VehicleModel.VehicleMakeId == vehicleQuery.VehicleMakeId.Value);

            if (vehicleQuery.SortBy == "vehicleMake")
            {
                query = (vehicleQuery.IsSortAscending) ? query.OrderBy(v => v.VehicleModel.VehicleMake.Name) : query.OrderByDescending(v => v.VehicleModel.VehicleMake.Name);
            }

            if (vehicleQuery.SortBy == "vehicleModel")
            {
                query = (vehicleQuery.IsSortAscending) ? query.OrderBy(v => v.VehicleModel.Name) : query.OrderByDescending(v => v.VehicleModel.Name);
            }

            if (vehicleQuery.SortBy == "ownersEmail")
            {
                query = (vehicleQuery.IsSortAscending) ? query.OrderBy(v => v.OwnerEmail) : query.OrderByDescending(v => v.OwnerEmail);
            }

            if (vehicleQuery.SortBy == "id")
            {
                query = (vehicleQuery.IsSortAscending) ? query.OrderBy(v => v.Id) : query.OrderByDescending(v => v.Id);
            }

            query = query.Skip((vehicleQuery.Page - 1) * vehicleQuery.PageSize).Take(vehicleQuery.PageSize);

            var vehicles = await query.ToListAsync();

            return vehicles;
        }

        async Task<IEnumerable<VehicleMakeResource>> IVehicleRepository.GetVehicleMakes()
        {
            var vehiclemakes = await context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();

            return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
        }

        async Task<Vehicle> IVehicleRepository.GetVehicle(int id, bool includeRelated)
        {
            return await context.Vehicles.FindAsync(id);
        }

        async Task<Vehicle> IVehicleRepository.CreateVehicle(SaveVehicleResource vehicleResource)
        {


            var vehicle = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            return vehicle;
        }

        async Task<Vehicle> IVehicleRepository.EditVehicle(Vehicle vehicle, SaveVehicleResource vehicleResource)
        {
            var result = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            return result;
        }

        public async Task<SaveVehicleResource> MapVehicle(Vehicle vehicle)
        {
            var result = vmapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return result;
        }
    }
}
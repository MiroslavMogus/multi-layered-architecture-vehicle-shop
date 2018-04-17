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

        /// <summary>
        /// Gets the UnitOfWork.
        /// </summary>
        /// <value>The UnitOfWork.</value>
        private readonly IUnitOfWork UnitOfWork;

        public object Vehicles => throw new System.NotImplementedException();

        public VehicleRepository(VehicleShopDbContext context, IMapper vmapper, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.vmapper = vmapper;
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returning total number of vehicles 
        /// to use that number in calculation of pagination.
        /// </summary>
        /// <returns>int</returns>
        async Task<int> IVehicleRepository.GetVehiclesTotal()
        {
            var query = context.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(m => m.VehicleMake)
                .AsQueryable();

            return query.Count();
        }

        /// <summary>
        /// Query for filtering returned vehicles
        /// to retrieve paginated results.
        /// </summary>
        /// <returns>Vehicle</returns>
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

        /// <summary>
        /// Returning Vehicle Makes froma database.
        /// </summary>
        /// <returns>IEnumerable<VehicleMakeResource></returns>
        async Task<IEnumerable<VehicleMakeResource>> IVehicleRepository.GetVehicleMakes()
        {
            var vehiclemakes = await context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();

            return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
        }

        /// <summary>
        /// Returning Vehicle from database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.GetVehicle(int id, bool includeRelated)
        {

            Vehicle found = await context.Vehicles.FindAsync(id);

            return found;
        }

        /// <summary>
        /// Create Vehicle and save to database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.CreateVehicle(SaveVehicleResource vehicleResource)
        {

            var vehicle = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            await UnitOfWork.AddAsync(vehicle);

            UnitOfWork.CommitAsync();

            return vehicle;
        }

        /// <summary>
        /// Edit existing Vehicle and save to database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.EditVehicle(Vehicle vehicle, SaveVehicleResource vehicleResource)
        {
            await UnitOfWork.UpdateAsync(vehicle);

            UnitOfWork.CommitAsync();

            var result = vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            return result;
        }

        /// <summary>
        /// Delete existing vehicle in database.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> DeleteVehicle(Vehicle vehicle)
        {
            await UnitOfWork.DeleteAsync(vehicle);

            UnitOfWork.CommitAsync();

            return vehicle;

        }

        /// <summary>
        /// Map existing Vehicle with VehicleResource
        /// to prevent overposting attack.
        /// </summary>
        /// <returns>Vehicle</returns>
        public async Task<SaveVehicleResource> MapVehicle(Vehicle vehicle)
        {
            var result = vmapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return result;
        }
    }
}
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
        private readonly VehicleShopDbContext Context;
        private readonly IMapper Vmapper;

        /// <summary>
        /// Gets the UnitOfWork.
        /// </summary>
        /// <value>The UnitOfWork.</value>
        private readonly IUnitOfWork UnitOfWork;

        public object Vehicles => throw new System.NotImplementedException();

        public VehicleRepository(VehicleShopDbContext context, IMapper vmapper, IUnitOfWork unitOfWork)
        {
            this.Context = context;
            this.Vmapper = vmapper;
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returning total number of vehicles 
        /// to use that number in calculation of pagination.
        /// </summary>
        /// <returns>int</returns>
        async Task<int> IVehicleRepository.GetVehiclesTotal()
        {
            var query = Context.Vehicles
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
        async Task<IEnumerable<Vehicle>> IVehicleRepository.GetVehicles(ObjectQuery VehicleQuery)
        {
            var query = Context.Vehicles
            .Include(v => v.VehicleModel)
            .ThenInclude(m => m.VehicleMake)
            .AsQueryable();

            if (VehicleQuery.VehicleMakeId.HasValue)
                query = query.Where(v => v.VehicleModel.VehicleMakeId == VehicleQuery.VehicleMakeId.Value);

            if (VehicleQuery.SortBy == "vehicleMake")
            {
                query = (VehicleQuery.IsSortAscending) ? query.OrderBy(v => v.VehicleModel.VehicleMake.Name) : query.OrderByDescending(v => v.VehicleModel.VehicleMake.Name);
            }

            if (VehicleQuery.SortBy == "vehicleModel")
            {
                query = (VehicleQuery.IsSortAscending) ? query.OrderBy(v => v.VehicleModel.Name) : query.OrderByDescending(v => v.VehicleModel.Name);
            }

            if (VehicleQuery.SortBy == "ownersEmail")
            {
                query = (VehicleQuery.IsSortAscending) ? query.OrderBy(v => v.OwnerEmail) : query.OrderByDescending(v => v.OwnerEmail);
            }

            if (VehicleQuery.SortBy == "id")
            {
                query = (VehicleQuery.IsSortAscending) ? query.OrderBy(v => v.Id) : query.OrderByDescending(v => v.Id);
            }

            query = query.Skip((VehicleQuery.Page - 1) * VehicleQuery.PageSize).Take(VehicleQuery.PageSize);

            var vehicles = await query.ToListAsync();

            return vehicles;
        }

        /// <summary>
        /// Returning Vehicle Makes froma database.
        /// </summary>
        /// <returns>IEnumerable<VehicleMakeResource></returns>
        async Task<IEnumerable<VehicleMakeResource>> IVehicleRepository.GetVehicleMakes()
        {
            var VehicleMakes = await Context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();

            return Vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(VehicleMakes);
        }

        /// <summary>
        /// Returning Vehicle from database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.GetVehicle(int Id, bool includeRelated)
        {

            Vehicle Found = await Context.Vehicles.FindAsync(Id);

            return Found;
        }

        /// <summary>
        /// Create Vehicle and save to database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.CreateVehicle(SaveVehicleResource vehicleResource)
        {

            var vehicle = Vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            await UnitOfWork.AddAsync(vehicle);

            await UnitOfWork.CommitAsync();

            return vehicle;
        }

        /// <summary>
        /// Edit existing Vehicle and save to database.
        /// </summary>
        /// <returns>Vehicle</returns>
        async Task<Vehicle> IVehicleRepository.EditVehicle(Vehicle vehicle, SaveVehicleResource vehicleResource)
        {

            var result = Vmapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            await UnitOfWork.UpdateAsync(result);

            await UnitOfWork.CommitAsync();

            return result;
        }

        /// <summary>
        /// Delete existing vehicle in database.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> DeleteVehicle(Vehicle vehicle)
        {
            await UnitOfWork.DeleteAsync(vehicle);

            await UnitOfWork.CommitAsync();

            return vehicle;

        }

        /// <summary>
        /// Map existing Vehicle with VehicleResource
        /// to prevent overposting attack.
        /// </summary>
        /// <returns>Vehicle</returns>
        public async Task<SaveVehicleResource> MapVehicle(Vehicle vehicle)
        {
            var result = Vmapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return result;
        }
    }
}
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.Service.Common;

namespace VehicleShopApp.Service
{
    public class VehicleService : IVehicleService
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>The repository.</value>
        protected IVehicleRepository Repository { get; private set; }

        /// <summary>
        /// Gets the UnitOfWork.
        /// </summary>
        /// <value>The UnitOfWork.</value>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Gets the Mapper.
        /// </summary>
        /// <value>The Mapper.</value>
        private readonly IMapper Mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The UnitOfWork.</param>
        /// <param name="mapper">The mapper.</param>
        public VehicleService(IVehicleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.Repository = repository;
            this.UnitOfWork = unitOfWork;
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes()
        {
            return await Repository.GetVehicleMakes();
        }

        /// <summary>
        /// Gets all available vehicles.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VehicleResource>> GetVehicles(ObjectQueryResource queryResource)
        {
            var query = Mapper.Map<ObjectQueryResource, ObjectQuery>(queryResource);

            var vehicles = await Repository.GetVehicles(query);

            return Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
        }

        /// <summary>
        /// Gets total vehicles number.
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetVehiclesTotal()
        {
            var total = await Repository.GetVehiclesTotal();

            return total;
        }

        /// <summary>
        /// Create new vehicle and store it to database.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> CreateVehicle(SaveVehicleResource vehicleResource)
        {
            var vehicle = await Repository.CreateVehicle(vehicleResource);

            return vehicle;
        }

        /// <summary>
        /// Edit existing vehicle and update database.
        /// </summary>
        /// <returns></returns>
        public async Task<SaveVehicleResource> EditVehicle(int id, SaveVehicleResource vehicleResource)
        {

            var vehicle = await Repository.GetVehicle(id);

            await Repository.EditVehicle(vehicle, vehicleResource);

            var result = await Repository.MapVehicle(vehicle);

            return result;
        }

        /// <summary>
        /// Delete existing vehicle in database.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> DeleteVehicle(int id)
        {
            Vehicle vehicle = await Repository.GetVehicle(id);

            var result = await Repository.DeleteVehicle(vehicle);

            return result;
        }

        /// <summary>
        /// Get vehicle from database by id.
        /// </summary>
        /// <returns></returns>
        public async Task<VehicleResource> GetVehicleResource(int id)
        {
            var vehicle = await Repository.GetVehicle(id);

            var vehicleResource = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return vehicleResource;
        }

        /// <summary>
        /// Get vehicle from database by id.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = await Repository.GetVehicle(id);

            return vehicle;
        }
    }
}

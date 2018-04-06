using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.Resources;
using VehicleShopApp.Service.Common;

namespace VehicleShopApp.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The UnitOfWork.</param>
        public VehicleService(IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.Repository = repository;
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>The repository.</value>
        protected IVehicleRepository Repository { get; private set; }

        public IEnumerable<VehicleMakeResource> GetVehicleMakes()
        {
            return Repository.GetVehicleMakes();
        }

        /// <summary>
        /// Gets all available vehicles.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VehicleResource>> GetVehicles()
        {
            return await Repository.GetVehicles();
        }

        /// <summary>
        /// Create new vehicle and store it to database.
        /// </summary>
        /// <returns></returns>
        public async Task<Vehicle> CreateVehicle(SaveVehicleResource vehicleResource)
        {
            var vehicle = Repository.CreateVehicle(vehicleResource);
            
            await UnitOfWork.AddAsync(vehicle);

            UnitOfWork.CommitAsync();

            return vehicle;
        }

        /// <summary>
        /// Edit existing vehicle and update database.
        /// </summary>
        /// <returns></returns>
        public async Task<SaveVehicleResource> EditVehicle(int id, SaveVehicleResource vehicleResource)
        {
            var vehicle = Repository.GetVehicle(id);
            
            Repository.EditVehicle(vehicle, vehicleResource);

            await UnitOfWork.UpdateAsync(vehicle);

            UnitOfWork.CommitAsync();
            
            var result = Repository.MapVehicle(vehicle);

            return result;
        }

        /// <summary>
        /// Delete existing vehicle in database.
        /// </summary>
        /// <returns></returns>
        public async Task<SaveVehicleResource> DeleteVehicle(int id)
        {
            var vehicle = Repository.GetVehicle(id);

            await UnitOfWork.DeleteAsync(vehicle);

            UnitOfWork.CommitAsync();

            SaveVehicleResource result = null;
            return result;
        }
    }
}

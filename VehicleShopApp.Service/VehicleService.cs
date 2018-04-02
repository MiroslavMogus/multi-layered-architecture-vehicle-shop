using System.Collections.Generic;
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
        public IEnumerable<VehicleResource> GetVehicles()
        {
            return Repository.GetVehicles();
        }

        public async void CreateVehicle(SaveVehicleResource vehicleResource)
        {
            var vehicle = Repository.CreateVehicle(vehicleResource);
            
            await UnitOfWork.AddAsync(vehicle);

            UnitOfWork.CommitAsync();
        }

    }
}

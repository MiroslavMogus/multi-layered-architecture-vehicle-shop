using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShop.Controllers.Resources;
using VehicleShop.Core;

namespace VehicleShop.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly IMapper vmapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehicleMakesController(IMapper vmapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.vmapper = vmapper;
        }
        [HttpGet("/api/vehiclemakes")]

        public async Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes()
        {
            /* Before dependency injection pattern implementation
             * var vehiclemakes = await context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();
             * return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
             */

            // After implementation
            return await repository.GetVehicleMakes();
        }
    }
}
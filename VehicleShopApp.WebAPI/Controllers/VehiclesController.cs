using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleShopApp.DAL;
using VehicleShopApp.Model;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.Resources;

namespace VehicleShopApp.WebAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VehicleShopDbContext context;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, VehicleShopDbContext context, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/api/vehicles")]

        public async Task<IEnumerable<VehicleResource>> GetVehicles()
        {
            /* Before dependency injection pattern implementation
             * var vehiclemakes = await context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();
             * return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
             */

            // After implementation
            return await repository.GetVehicles();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            //context.Vehicles.Add(vehicle);

            //await context.SaveChangesAsync();
            await unitOfWork.AddAsync(vehicle);

            await unitOfWork.CommitAsync();

            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {

            var vehicle = await context.Vehicles.FindAsync(id);


            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(vehicle);

        }

    }
}

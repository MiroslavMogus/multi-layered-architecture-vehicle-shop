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
    public class VehiclesController: Controller
    {
        private readonly IMapper mapper;
        private readonly VehicleShopDbContext context;
        private readonly IVehicleRepository repository;

        public VehiclesController(IMapper mapper, VehicleShopDbContext context, IVehicleRepository repository)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            context.Vehicles.Add(vehicle);

            await context.SaveChangesAsync();

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

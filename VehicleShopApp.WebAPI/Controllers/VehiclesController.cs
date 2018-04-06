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
using VehicleShopApp.Service.Common;

namespace VehicleShopApp.WebAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VehicleShopDbContext context;
        private readonly IVehicleRepository Repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicleService service;

        public VehiclesController(IMapper mapper, VehicleShopDbContext context, IVehicleRepository repository, IUnitOfWork unitOfWork, IVehicleService service)
        {
            this.mapper = mapper;
            this.context = context;
            this.Repository = repository;
            this.unitOfWork = unitOfWork;
            this.service = service;
        }

        [HttpGet("/api/vehicles")]

        public async Task <IEnumerable<VehicleResource>> GetVehicles()
        {
            return await service.GetVehicles();
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = Repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            var vehicle = service.CreateVehicle(vehicleResource);

            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            var vehicle = Repository.GetVehicle(id);

            var result = service.EditVehicle(id, vehicleResource);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {

            var result = service.DeleteVehicle(id);

            return Ok(result);
        }
    }
}

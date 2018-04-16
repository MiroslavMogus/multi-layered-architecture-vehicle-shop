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
using VehicleShopApp.Service.Common;

namespace VehicleShopApp.WebAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService service;

        public VehiclesController(IVehicleService service)
        {
            this.service = service;
        }

        [HttpGet("/api/vehicles")]
        public async Task<IEnumerable<VehicleResource>> GetVehicles(ObjectQueryResource query)
        {
            return await service.GetVehicles(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await service.GetVehicle(id);

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            var vehicle = await service.CreateVehicle(vehicleResource);

            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            var result = await service.EditVehicle(id, vehicleResource);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            var result = await service.DeleteVehicle(id);

            return Ok(result);
        }
    }
}

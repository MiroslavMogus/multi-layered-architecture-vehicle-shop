using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleShopApp.Model;

namespace VehicleShopApp.WebAPI.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController: Controller
    {
        [HttpPost]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            return Ok(vehicle);
        }
    }
}

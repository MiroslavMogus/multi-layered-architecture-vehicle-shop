using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShopApp.Resources;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.Model;

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

        public IEnumerable<VehicleMakeResource> GetVehicleMakes()
        {
            return repository.GetVehicleMakes();
        }
    }
}
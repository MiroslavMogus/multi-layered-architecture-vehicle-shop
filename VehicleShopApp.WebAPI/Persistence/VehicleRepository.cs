using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VehicleShop.Controllers.Resources;
using VehicleShop.Core;
using VehicleShop.Core.Models;

namespace VehicleShop.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleShopDbContext context;
        private readonly IMapper vmapper;
        public VehicleRepository(VehicleShopDbContext context, IMapper vmapper)
        {
            this.context = context;
            this.vmapper = vmapper;
        }

        public async Task<IEnumerable<VehicleMakeResource>> GetVehicleMakes()
        { 
            var vehiclemakes = await context.VehicleMakes.Include(m => m.VehicleModels).ToListAsync();

            return vmapper.Map<List<VehicleMake>, List<VehicleMakeResource>>(vehiclemakes);
        }
    }
}
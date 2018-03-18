using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VehicleShopApp.Repository.Common;
using VehicleShopApp.DAL;
using VehicleShopApp.Resources;
using VehicleShopApp.Model;
using Microsoft.EntityFrameworkCore;

namespace VehicleShopApp.Repository
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
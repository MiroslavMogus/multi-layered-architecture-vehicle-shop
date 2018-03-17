using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShop.Core.Models;
using VehicleShop.Core;
using VehicleShop.Persistence;

namespace VehicleShop.Controllers.Resources
{
public class VehicleFeaturesController : Controller
  {
    private readonly VehicleShopDbContext context;
    private readonly IMapper mapper;
    public VehicleFeaturesController(VehicleShopDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet("/api/vehiclefeatures")]
    public async Task<IEnumerable<VehicleFeatureResource>> GetFeatures()
    {
      var features = await context.VehicleFeatures.ToListAsync();
      
      return mapper.Map<List<VehicleFeature>, List<VehicleFeatureResource>>(features); 
    }
  }
}
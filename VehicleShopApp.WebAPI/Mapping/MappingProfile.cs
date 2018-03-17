using AutoMapper;
using VehicleShop.Controllers.Resources;
using VehicleShop.Core;
using VehicleShop.Core.Models;

namespace VehicleShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, VehicleMakeResource>();
            CreateMap<VehicleModel, VehicleModelResource>();
            CreateMap<VehicleFeature, VehicleFeatureResource>();
        }
    }
}
using AutoMapper;
using VehicleShopApp.Resources;
using VehicleShopApp.Model;

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
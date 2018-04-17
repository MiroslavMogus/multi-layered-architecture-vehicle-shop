using AutoMapper;
using VehicleShopApp.Resources;
using VehicleShopApp.Model;

namespace VehicleShopApp.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, Model.VehicleMakeResource>();
            CreateMap<VehicleModel, Model.VehicleModelResource>();
            CreateMap<Vehicle, Model.VehicleResource>();
            CreateMap<Vehicle, Model.SaveVehicleResource>();
        }
    }
}
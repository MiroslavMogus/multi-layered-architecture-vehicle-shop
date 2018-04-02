﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShopApp.Model;
using VehicleShopApp.Resources;

namespace VehicleShopApp.Service.Common
{
    public interface IVehicleService
    {
        IEnumerable<VehicleResource> GetVehicles();
        IEnumerable<VehicleMakeResource> GetVehicleMakes();
        Task<Vehicle> CreateVehicle(SaveVehicleResource vehicleResource);
        Task<SaveVehicleResource> EditVehicle(int id, SaveVehicleResource vehicleResource);
    }
}

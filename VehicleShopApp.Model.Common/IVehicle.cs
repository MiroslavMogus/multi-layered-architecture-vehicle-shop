using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model.Common
{
    class IVehicle
    {
        public int Id { get; set; }

        public IVehicleModel VehicleModel { get; set; }

        public IVehicleMake VehicleMake { get; set; }

        public string OwnerEmail { get; set; }
    }
}

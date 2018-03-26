using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model.Common
{
    class IVehicle
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public IVehicleModel VehicleModel { get; set; }
    }
}

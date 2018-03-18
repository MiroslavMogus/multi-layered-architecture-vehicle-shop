using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model.Common
{
    class IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IVehicleMake VehicleMake { get; set; }
        public int VehicleMakeId { get; set; }
    }
}

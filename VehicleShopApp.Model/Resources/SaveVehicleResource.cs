using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public string OwnerEmail { get; set; }
    }
}

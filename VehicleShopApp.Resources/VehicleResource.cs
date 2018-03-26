using System;
using System.Collections.Generic;
using System.Text;
using VehicleShopApp.Model;

namespace VehicleShopApp.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public int VehicleMakelId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public string OwnerEmail { get; set; }

    }
}

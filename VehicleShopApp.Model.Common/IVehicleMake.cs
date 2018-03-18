using System;
using System.Collections.Generic;

namespace VehicleShopApp.Model.Common
{
    public class IVehicleMake
    {
        public int Id { get; set; }

        public string Name { get; set; }

        ICollection<IVehicleModel> VehicleModels { get; set; }

    }
}

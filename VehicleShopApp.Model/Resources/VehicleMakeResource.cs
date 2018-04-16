using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VehicleShopApp.Model
{
    public class VehicleMakeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehicleModelResource> VehicleModels { get; set; }
        public VehicleMakeResource()
        {
            VehicleModels = new Collection<VehicleModelResource>();
        }
    }
}
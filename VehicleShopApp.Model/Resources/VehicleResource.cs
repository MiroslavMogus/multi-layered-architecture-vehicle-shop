using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VehicleShopApp.Model;

namespace VehicleShopApp.Model
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public VehicleMake VehicleMake { get; set; }

        public string OwnerEmail { get; set; }

        public ICollection<VehicleMakeResource> VehicleMakes { get; set; }

        public VehicleResource()
        {
            VehicleMakes = new Collection<VehicleMakeResource>();
        }
    }
}

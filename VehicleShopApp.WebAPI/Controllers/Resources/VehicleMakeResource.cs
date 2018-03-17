using System.Collections.Generic;
using System.Collections.ObjectModel;
using VehicleShop.Core.Models;

namespace VehicleShop.Controllers.Resources
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
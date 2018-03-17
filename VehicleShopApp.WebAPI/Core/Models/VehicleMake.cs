using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleShop.Core.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }

        public VehicleMake()
        {
            VehicleModels = new Collection<VehicleModel>();
        }
    }
}
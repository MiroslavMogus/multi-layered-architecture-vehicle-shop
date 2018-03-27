using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleShopApp.Model
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get;  set; }

        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public VehicleMake VehicleMake { get; set; }

        public string OwnerEmail { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using VehicleShopApp.Model;

namespace VehicleShopApp.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public string OwnerEmail { get; set; }
    }
}
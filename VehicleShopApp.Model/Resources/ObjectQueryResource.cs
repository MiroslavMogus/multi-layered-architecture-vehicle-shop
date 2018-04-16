using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model
{
    public class ObjectQueryResource
    {
        public int? VehicleMakeId { get; set; }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}

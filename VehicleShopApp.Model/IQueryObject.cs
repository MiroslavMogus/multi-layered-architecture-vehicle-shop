using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleShopApp.Model
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}

using VehicleShopApp.Model;

namespace VehicleShopApp.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public string OwnerEmail { get; set; }
    }
}

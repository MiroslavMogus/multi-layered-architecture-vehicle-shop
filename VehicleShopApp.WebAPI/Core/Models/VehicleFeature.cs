using System.ComponentModel.DataAnnotations;

namespace VehicleShop.Core.Models
{
    public class VehicleFeature
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
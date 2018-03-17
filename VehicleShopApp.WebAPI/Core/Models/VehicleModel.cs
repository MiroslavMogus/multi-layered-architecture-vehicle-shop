using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShop.Core.Models
{
    [Table("VehicleModels")]
    public class VehicleModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

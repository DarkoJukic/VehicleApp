using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.Model
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> Models { get; set; }
    }
}
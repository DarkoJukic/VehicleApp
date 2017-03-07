using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> Models { get; set; }
    }
}
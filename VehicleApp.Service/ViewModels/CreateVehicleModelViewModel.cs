using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Service.ViewModels
{
    public class CreateVehicleModelViewModel
    {
        public int Id { get; set; }
        [Required]
        public int VehicleMakeId { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

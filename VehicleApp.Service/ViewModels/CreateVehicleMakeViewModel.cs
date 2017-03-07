using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.ViewModels
{
    public class CreateVehicleMakeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vehicle Make")]
        public string Name { get; set; }
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.ViewModels
{
    public class ListVehicleMakeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Make")]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

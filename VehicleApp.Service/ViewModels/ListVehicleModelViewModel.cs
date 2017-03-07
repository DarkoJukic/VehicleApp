using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.ViewModels
{
    public class ListVehicleModelViewModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        public string Abrv { get; set; }
    }
}

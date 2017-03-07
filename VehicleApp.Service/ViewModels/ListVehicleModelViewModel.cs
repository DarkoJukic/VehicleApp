using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.ViewModels
{
    public class ListVehicleModelViewModel
    {
        [Display( )]
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        [Display(Name = "Model")]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

using VehicleApp.Model.Common;

namespace VehicleApp.Model
{
    public class VehicleModelPoco : IVehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

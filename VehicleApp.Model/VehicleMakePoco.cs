using System.Collections.Generic;
using VehicleApp.Model.Common;

namespace VehicleApp.Model
{
    public class VehicleMakePoco : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModelPoco> Models { get; set; }
    }
}
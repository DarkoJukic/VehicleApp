using System.Collections.Generic;
using VehicleApp.Model;

namespace VehicleApp.Service.Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<VehicleModel> Models { get; set; }
    }
}

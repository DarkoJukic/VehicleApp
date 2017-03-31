using System.Collections.Generic;
using VehicleApp.Model;

namespace VehicleApp.Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        //ICollection<IVehicleModel> Models { get; set; }
    }
}

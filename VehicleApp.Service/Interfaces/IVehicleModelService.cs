using System.Collections.Generic;
using VehicleApp.Service.Models;

namespace VehicleApp.Service.Interfaces
{
    public interface IVehicleModelService
    {
        IEnumerable<VehicleMake> Get(int MakeId);
        void Create(VehicleMake vehicleMake);
        VehicleModel Edit(int? Id);
        void Edit(VehicleModel vehicleModel);
        VehicleModel Delete(int? Id);
        void DeleteConfirmed(int? Id);
    }
}

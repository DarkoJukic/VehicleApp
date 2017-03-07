using System.Collections.Generic;
using VehicleApp.Service.Models;

namespace VehicleApp.Service.Interfaces
{
    public interface IVehicleModelService
    {
        IEnumerable<VehicleModel> Get(int MakeId);
        void Create(VehicleModel vehicleMake);
        VehicleModel Edit(int? Id);
        void Edit(VehicleModel vehicleModel);
        VehicleModel Delete(int? Id);
        void DeleteConfirmed(int? Id);
    }
}

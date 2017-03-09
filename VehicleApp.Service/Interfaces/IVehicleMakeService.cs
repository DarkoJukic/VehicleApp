using System.Collections.Generic;
using VehicleApp.Service.Models;

namespace VehicleApp.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        List<VehicleMake> Get(string searchTerm);
        void Create(VehicleMake vehicleMake);
        VehicleMake Edit(int? Id);
        void Edit(VehicleMake vehicleMake);
        VehicleMake Delete(int? Id);
        void DeleteConfirmed(int? Id);
    }
}

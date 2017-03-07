using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Service.Models;

namespace VehicleApp.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        List<VehicleMake> Get();
        void Create(VehicleMake vehicleMake);
        VehicleMake Edit(int? Id);
        void Edit(VehicleMake vehicleMake);
        VehicleMake Delete(int? Id);
        void DeleteConfirmed(int? Id);
    }
}

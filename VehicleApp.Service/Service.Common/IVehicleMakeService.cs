using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMake>> GetAllVehicleMakes(int? page, string searchBy, string searchTerm, string sortBy);
        VehicleMake CreateVehicleMake(VehicleMake vehicleMake);
        VehicleMake EditVehicleMake(int? Id);
        void EditVehicleMake(VehicleMake vehicleMake);
        VehicleMake DeleteVehicleMake(int? Id);
        void DeleteVehicleMakeConfirmed(int? Id);
    }
}

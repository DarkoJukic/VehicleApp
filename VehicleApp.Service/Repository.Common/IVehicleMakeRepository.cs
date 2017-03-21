using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository.Interfaces
{
    public interface IVehicleMakeRepository
    {
        Task<List<VehicleMake>> Get(int? page, string searchBy, string searchTerm, string sortBy);
        VehicleMake Create(VehicleMake vehicleMake);
        VehicleMake Edit(int? Id);
        void Edit(VehicleMake vehicleMake);
        VehicleMake Delete(int? Id);
        void DeleteConfirmed(int? Id);
    }
}

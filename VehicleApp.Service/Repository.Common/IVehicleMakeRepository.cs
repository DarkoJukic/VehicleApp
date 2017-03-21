using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository.Interfaces
{
    public interface IVehicleMakeRepository
    {
        Task<List<VehicleMake>> Get(int? page, string searchBy, string searchTerm, string sortBy);
        Task<VehicleMake> Create(VehicleMake vehicleMake);
        Task<VehicleMake> Edit(int? Id);
        Task Edit(VehicleMake vehicleMake);
        Task<VehicleMake> Delete(int? Id);
        Task DeleteConfirmed(int? Id);
    }
}

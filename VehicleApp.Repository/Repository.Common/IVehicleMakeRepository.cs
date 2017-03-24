using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository.Interfaces
{
    public interface IVehicleMakeRepository
    {
        Task<List<VehicleMake>> Get(int? page, string searchBy, string searchTerm, string sortBy);
        Task<VehicleMake> CreateAsync(VehicleMake vehicleMake);
        //Task<VehicleMake> Edit(int? Id);
        Task EditAsync(VehicleMake vehicleMake);
        //Task<VehicleMake> Delete(int? Id);
        Task DeleteAsync(int? Id);
        Task SaveAsync();
    }
}

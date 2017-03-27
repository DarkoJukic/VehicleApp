using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortBy);
        Task<VehicleMake> CreateMake(VehicleMake vehicleMake);
        Task EditMake(VehicleMake vehicleMake);
        Task DeleteMake(int Id);
    }
}

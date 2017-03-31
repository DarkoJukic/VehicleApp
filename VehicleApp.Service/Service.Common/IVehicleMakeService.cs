using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortBy);
        Task<IVehicleMake> CreateMake(IVehicleMake vehicleMake);
        Task EditMake(IVehicleMake vehicleMake);
        Task DeleteMake(int Id);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Common.Filters;
using VehicleApp.Model.Common;

namespace VehicleApp.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(IPagingFilter filter);
        Task<IVehicleMake> CreateMake(IVehicleMake vehicleMake);
        Task EditMake(IVehicleMake vehicleMake);
        Task DeleteMake(int Id);
    }
}

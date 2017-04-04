using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Common.Filters;
using VehicleApp.Model;
using VehicleApp.Model.Common;

namespace VehicleApp.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetPageAsync(IPagingFilter filter);
        Task<IVehicleMake> AddAsync(IVehicleMake make);
        Task<int> UpdateAsync(IVehicleMake make);
        Task<int> DeleteAsync(int id);
    }
}

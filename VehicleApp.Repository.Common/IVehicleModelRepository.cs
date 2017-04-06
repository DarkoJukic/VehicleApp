using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Model.Common;

namespace VehicleApp.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetByMakeId(int MakeId);
        Task<IVehicleModel> AddAsync(IVehicleModel model);
        Task<int> UpdateAsync(IVehicleModel model);
        Task<int> DeleteAsync(int id);
    }
}
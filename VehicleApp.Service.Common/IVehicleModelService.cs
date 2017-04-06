using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model.Common;

namespace VehicleApp.Service.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetModelsByMakeId(int Id);
        Task<IVehicleModel> CreateModel(IVehicleModel model);
        Task EditModel(IVehicleModel model);
        Task DeleteModel(int Id);
    }
}

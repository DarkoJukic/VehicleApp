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

        //IVehicleMake Add(IVehicleMake vehicleMake);
        //Task<IVehicleMake> Edit(int? Id);
        //void EditAsync(IVehicleMake vehicleMake);
        //Task<IVehicleMake> Delete(int? Id);
        //Task DeleteAsync(int? Id);
        //Task SaveAsync();
    }
}

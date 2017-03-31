using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Model.Common;

namespace VehicleApp.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetPageAsync(int? page, string searchBy, string searchTerm, string sortBy);

        //IVehicleMake Add(IVehicleMake vehicleMake);
        //Task<IVehicleMake> Edit(int? Id);
        //void EditAsync(IVehicleMake vehicleMake);
        //Task<IVehicleMake> Delete(int? Id);
        //Task DeleteAsync(int? Id);
        //Task SaveAsync();
    }
}

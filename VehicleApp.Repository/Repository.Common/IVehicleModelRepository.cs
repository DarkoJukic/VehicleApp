using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository.Interfaces
{
    public interface IVehicleModelRepository : IRepository<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetByMakeId(int MakeId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model;

namespace VehicleApp.Service.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleApp.Repository.Models.VehicleModel>> GetModelsByMakeId(int Id);
    }
}

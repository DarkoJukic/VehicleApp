using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Service.Service.Common;

namespace VehicleApp.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository repository;
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<VehicleApp.Repository.Models.VehicleModel>> GetModelsByMakeId(int Id)
        {
            return await repository.Get(Id);
        }
    }
}

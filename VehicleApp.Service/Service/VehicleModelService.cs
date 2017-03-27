using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Service.Service.Common;

namespace VehicleApp.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IUnitOfWork unitOfWork;
        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VehicleApp.Repository.Models.VehicleModel>> GetModelsByMakeId(int Id)
        {
            return await unitOfWork.Models.GetByMakeId(Id);
        }
    }
}

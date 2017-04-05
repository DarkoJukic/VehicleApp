using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;

namespace VehicleApp.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IRepository Repository { get; private set; }

        public VehicleModelRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IEnumerable<IVehicleModel>> GetByMakeId(int MakeId)
        {
            //
            var model = Repository.GetWhere<VehicleModel>()
                .Where(s=> s.VehicleMakeId == MakeId).ToList();

            return Mapper.Map<IEnumerable<IVehicleModel>>(model);              
        }
    }
}

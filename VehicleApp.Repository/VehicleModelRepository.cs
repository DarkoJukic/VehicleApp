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
            var model = Repository.GetWhere<VehicleModel>()
                .Where(s=> s.VehicleMakeId == MakeId).ToList();

            return Mapper.Map<IEnumerable<IVehicleModel>>(model);              
        }
        public async virtual Task<IVehicleModel> AddAsync(IVehicleModel model)
        {
            var returnedModel = await Repository.AddAsync(Mapper.Map<VehicleModel>(model));
            return Mapper.Map<IVehicleModel>(returnedModel);
        }

        public async virtual Task<int> UpdateAsync(IVehicleModel model)
        {
            return await Repository.UpdateAsync(Mapper.Map<VehicleModel>(model));
        }

        public async virtual Task<int> DeleteAsync(int id)
        {
            return await Repository.DeleteAsync<VehicleModel>(id);
        }
    }
}

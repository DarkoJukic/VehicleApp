using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common.Filters;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;
using VehicleApp.Service.Service.Common;

namespace VehicleApp.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository Repository;
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IEnumerable<IVehicleModel>> GetModelsByMakeId(int Id)
        {
            var model = await Repository.GetByMakeId(Id);
            return model;
        }

        public async Task<IVehicleModel> CreateModel(IVehicleModel model)
        {
            model = await Repository.AddAsync(Mapper.Map<IVehicleModel>(model));
            return model;
        }

        public async Task EditModel(IVehicleModel model)
        {
            await Repository.UpdateAsync(Mapper.Map<IVehicleModel>(model));
        }

        public async Task DeleteModel(int Id)
        {
            {
                await Repository.DeleteAsync(Id);
            }
        }
    }
}

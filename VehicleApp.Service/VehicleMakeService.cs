using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.DAL;
using VehicleApp.Service.Common;
using VehicleApp.Model.Common;
using System;
using VehicleApp.Repository;
using VehicleApp.Common.Filters;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository Repository;

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IEnumerable<IVehicleMake>> GetAsync(IPagingFilter filter = null)
        {
            return await Repository.GetPageAsync(filter);
        }

        public async Task<IVehicleMake> CreateMake(IVehicleMake make)
        {
            make = await Repository.AddAsync(Mapper.Map<IVehicleMake>(make));
            return make;
        }

        public async Task EditMake(IVehicleMake make)
        {
            await Repository.UpdateAsync(Mapper.Map<IVehicleMake>(make));
        }

        public async Task DeleteMake(int Id)
        {
            {
                await Repository.DeleteAsync(Id);
            }
        }
    }
}

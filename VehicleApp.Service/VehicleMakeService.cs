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
        private VehicleMakeRepository repository;

        public VehicleMakeService(VehicleMakeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IVehicleMake>> GetAsync(IPagingFilter filter = null)
        {
            return await repository.GetPageAsync(filter);
            //return await unitOfWork.Makes.GetPage(page, searchBy, searchTerm, sortBy);
        }

        public async Task<IVehicleMake> CreateMake(IVehicleMake make)
        {

            make = await repository.AddAsync(Mapper.Map<IVehicleMake>(make));
            return make;
        }

        public async Task EditMake(IVehicleMake make)
        {

            await repository.UpdateAsync(Mapper.Map<IVehicleMake>(make));
        }

        public async Task DeleteMake(int Id)
        {
            {
                await repository.DeleteAsync(Id);
            }
        }
    }
}

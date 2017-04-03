using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.DAL;
using VehicleApp.Service.Common;
using VehicleApp.Model.Common;
using System;
using VehicleApp.Repository;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private VehicleMakeRepository repository;

        public VehicleMakeService(VehicleMakeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IVehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortBy)
        {
            return await repository.GetPageAsync(page, searchBy, searchTerm, sortBy);
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

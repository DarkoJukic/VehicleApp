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
            make = await repository.CreateAsync(make);
            //repository.Create(Mapper.Map<IVehicleMake>(make));
            //await repository.SaveChangesAsync();
            return make;
        }

        public async Task EditMake(IVehicleMake make)
        {
            await repository.EditAsync(make);
            //repository.Makes.Update(Mapper.Map<IVehicleMake>(vehicleMake));
            //await repository.SaveChangesAsync();
        }

        public async Task DeleteMake(int Id)
        {
            {
                await repository.DeleteAsync(Id);
                //var vehicleToDelete = await repository.Makes.SingleOrDefaultAsync(r => r.Id == Id);
                //repository.Makes.Remove(vehicleToDelete);
                //await repository.SaveChangesAsync();
            }
        }
    }
}

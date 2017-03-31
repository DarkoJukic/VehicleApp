using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Models;
using VehicleApp.Service.Common;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IUnitOfWork unitOfWork;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IVehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortBy)
        {
            return await unitOfWork.Makes.GetPage(page, searchBy, searchTerm, sortBy);
        }

        public async Task<IVehicleMake> CreateMake(IVehicleMake make)
        {
            unitOfWork.Makes.Add(Mapper.Map<VehicleMake>(make));
            await unitOfWork.SaveChangesAsync();
            return make;
        }

        public async Task EditMake(IVehicleMake vehicleMake)
        {
            unitOfWork.Makes.Update(Mapper.Map<VehicleMake>(vehicleMake));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMake(int Id)
        {
            {
                var vehicleToDelete = await unitOfWork.Makes.SingleOrDefaultAsync(r => r.Id == Id);
                unitOfWork.Makes.Remove(vehicleToDelete);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}

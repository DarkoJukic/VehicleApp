using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Models;
using VehicleApp.Service.Common;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IUnitOfWork unitOfWork;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortBy)
        {
            return await unitOfWork.Makes.GetPage(page, searchBy, searchTerm, sortBy);
        }

        public async Task<VehicleMake> CreateMake(VehicleMake vehicleMake)
        {
            unitOfWork.Makes.Add(vehicleMake);
            await unitOfWork.SaveChangesAsync();
            return vehicleMake;
        }

        public async Task EditMake(VehicleMake vehicleMake)
        {
            unitOfWork.Makes.Update(vehicleMake);
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

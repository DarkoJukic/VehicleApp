using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;
using VehicleApp.Service.Common;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository repository;
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<VehicleMake>> GetAllVehicleMakes(int? page, string searchBy, string searchTerm, string sortBy)
        {
            return await repository.Get(page, searchBy, searchTerm, sortBy);
        }

        public async Task<VehicleMake> CreateVehicleMake(VehicleMake vehicleMake)
        {
            await repository.CreateAsync(vehicleMake);
            return vehicleMake;
        }

        public async Task EditVehicleMake(VehicleMake vehicleMake)
        {
            await repository.EditAsync(vehicleMake);
        }

        public async Task DeleteVehicleMakeConfirmed(int? Id)
        {
            await repository.DeleteAsync(Id);
        }
    }
}

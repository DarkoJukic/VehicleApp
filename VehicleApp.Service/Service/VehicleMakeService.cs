using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<List<VehicleMake>> GetAllVehicleMakes(int? page, string searchBy, string searchTerm, string sortBy)
        {
            return repository.Get(page, searchBy, searchTerm, sortBy);
        }

        public void CreateVehicleMake(VehicleMake vehicleMake)
        {
            repository.Create(vehicleMake);
        }

        public VehicleMake EditVehicleMake(int? Id)
        {
            return repository.Edit(Id);
        }

        public void EditVehicleMake(VehicleMake vehicleMake)
        {
            repository.Edit(vehicleMake);
        }
        public VehicleMake DeleteVehicleMake(int? Id)
        {
            return repository.Delete(Id);
        }

        public void DeleteVehicleMakeConfirmed(int? Id)
        {
            repository.DeleteConfirmed(Id);
        }
    }
}

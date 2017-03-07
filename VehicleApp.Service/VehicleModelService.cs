using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Service.Interfaces;
using VehicleApp.Service.Models;

namespace VehicleApp.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public IEnumerable<VehicleModel> Get(int MakeId)
        {
            // Need to implement paging and filtering in future
            using (var context = new VehicleDbContext())
            {
                var model = context.Models.Where(vehicle => vehicle.VehicleMakeId == MakeId)
                    .OrderBy(vehicle => vehicle.Name)
                    .Take(10).ToList();
                return model;
            }
        }
        public void Create(VehicleModel vehicleMake)
        {
            throw new NotImplementedException();
        }

        public VehicleModel Delete(int? Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteConfirmed(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public VehicleModel Edit(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}

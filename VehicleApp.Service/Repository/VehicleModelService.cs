using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class VehicleModelService : IVehicleModelService
    {
        private VehicleDbContext context;
        public VehicleModelService(VehicleDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<VehicleModel> Get(int MakeId)
        {
            // Need to implement paging and filtering in future
            var model = context.Models.Where(vehicle => vehicle.VehicleMakeId == MakeId)
                .OrderBy(vehicle => vehicle.Name)
                .Take(10).ToList();
            return model;
        }
        public void Create(VehicleModel vehicleModel)
        {
            context.Models.Add(vehicleModel);
            context.SaveChanges();
        }

        public VehicleModel Edit(int? Id)
        {
            var model = context.Models.Find(Id);
            return model;
        }
        public void Edit(VehicleModel vehicleMake)
        {
            context.Entry(vehicleMake).State = EntityState.Modified;
            context.SaveChanges();
        }
        public VehicleModel Delete(int? Id)
        {

            return context.Models.Find(Id);

        }
        public void DeleteConfirmed(int? Id)
        {
            VehicleModel model = context.Models.Find(Id);
            context.Models.Remove(model);
            context.SaveChanges();
        }
    }
}

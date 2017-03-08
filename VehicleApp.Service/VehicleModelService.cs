using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void Create(VehicleModel vehicleModel)
        {
            using (var context = new VehicleDbContext())
            {
                context.Models.Add(vehicleModel);
                context.SaveChanges();
            }
        }

        public VehicleModel Edit(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                var model = context.Models.Find(Id);
                return model;
            }
        }
        public void Edit(VehicleModel vehicleMake)
        {
            using (var context = new VehicleDbContext())
            {
                context.Entry(vehicleMake).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public VehicleModel Delete(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                return context.Models.Find(Id);
            }
        }
        public void DeleteConfirmed(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                VehicleModel model = context.Models.Find(Id);
                context.Models.Remove(model);
                context.SaveChanges();
            }
        }
    }
}

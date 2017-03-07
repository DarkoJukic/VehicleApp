using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VehicleApp.Service.Interfaces;
using VehicleApp.Service.Models;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public List<VehicleMake> Get()
        {
            // Need to implement paging and filtering in future
            using (var context = new VehicleDbContext())
            {
                var model = context.Makes
                    .OrderBy(vehicle => vehicle.Name)
                    .Take(10).ToList();
                return model;
            }
        }

        public void Create(VehicleMake vehicleMake)
        {
            using (var context = new VehicleDbContext())
            {
                context.Makes.Add(vehicleMake);
                context.SaveChanges();
            }
        }

        public VehicleMake Edit(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                var model = context.Makes.Find(Id);
                return model;
            }
        }
        public void Edit(VehicleMake vehicleMake)
        {
            using (var context = new VehicleDbContext())
            {
                context.Entry(vehicleMake).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public VehicleMake Delete(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                return context.Makes.Find(Id);
            }
        }
        public void DeleteConfirmed(int? Id)
        {
            using (var context = new VehicleDbContext())
            {
                VehicleMake vehicleMake = context.Makes.Find(Id);
                context.Makes.Remove(vehicleMake);
                context.SaveChanges();
            }
        }
    }
}

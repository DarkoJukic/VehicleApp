using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VehicleApp.Service.Interfaces;
using VehicleApp.Service.Models;

namespace VehicleApp.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private VehicleDbContext context;
        public VehicleMakeService(VehicleDbContext context)
        {
            this.context = context;
        }
        public List<VehicleMake> Get(int? page, string searchBy, string searchTerm, string sortOrder)
        {
            var model = context.Makes.AsQueryable();

            if (searchBy == "Abrv")
            {
                model = model.Where(vehicle => vehicle.Abrv.StartsWith(searchTerm) || searchTerm == null);
            }
            else
            {
                model = model.Where(vehicle => vehicle.Name.StartsWith(searchTerm) || searchTerm == null);
            }

            switch (sortOrder)
            {
                case "NameDesc":
                   return model.OrderByDescending(vehicle => vehicle.Name)
                        .ToList();
                case "Abrv":
                    return model.OrderBy(vehicle => vehicle.Abrv)
                         .ToList();
                case "AbrvDesc":
                    return model.OrderByDescending(vehicle => vehicle.Abrv)
                         .ToList();             
                default:
                    return model.OrderBy(vehicle => vehicle.Name)
                         .ToList();
            }
        }

        public void Create(VehicleMake vehicleMake)
        {
            context.Makes.Add(vehicleMake);
            context.SaveChanges();
        }

        public VehicleMake Edit(int? Id)
        {
            var model = context.Makes.Find(Id);
            return model;
        }
        public void Edit(VehicleMake vehicleMake)
        {
            context.Entry(vehicleMake).State = EntityState.Modified;
            context.SaveChanges();
        }

        public VehicleMake Delete(int? Id)
        {
            return context.Makes.Find(Id);
        }
        public void DeleteConfirmed(int? Id)
        {
            VehicleMake vehicleMake = context.Makes.Find(Id);
            context.Makes.Remove(vehicleMake);
            context.SaveChanges();
        }
    }
}

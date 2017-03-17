using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleDbContext context;
        public VehicleMakeRepository(VehicleDbContext context)
        {
            this.context = context;
        }
        public async Task<List<VehicleMake>> Get(int? page, string searchBy, string searchTerm, string sortOrder)
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
                    return await model.OrderByDescending(vehicle => vehicle.Name).ToListAsync(); ;

                case "Abrv":
                    return await model.OrderBy(vehicle => vehicle.Abrv).ToListAsync(); ;

                case "AbrvDesc":
                    return await model.OrderByDescending(vehicle => vehicle.Abrv).ToListAsync(); ;

                default:
                    return await model.OrderBy(vehicle => vehicle.Name).ToListAsync();
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
            if (vehicleMake != null)
            {
                context.Makes.Remove(vehicleMake);
                context.SaveChanges();
            }
        }
    }
}

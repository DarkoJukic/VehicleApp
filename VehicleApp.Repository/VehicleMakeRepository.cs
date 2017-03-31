using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;
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
        public async Task<IEnumerable<IVehicleMake>> GetPageAsync(int? page, string searchBy, string searchTerm, string sortOrder)
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
                    model.OrderByDescending(vehicle => vehicle.Name);
                    break;

                case "Abrv":
                    model.OrderBy(vehicle => vehicle.Abrv);
                    break;

                case "AbrvDesc":
                    model.OrderByDescending(vehicle => vehicle.Abrv);
                    break;

                default:
                    model.OrderBy(vehicle => vehicle.Name);
                    break;

            }
            return Mapper.Map<IEnumerable<IVehicleMake>>(await model.ToListAsync());
        }

        public async Task<IVehicleMake> CreateAsync(IVehicleMake make)
        {
            var mapped = Mapper.Map<VehicleMake>(make);

            context.Makes.Add(mapped);
            await context.SaveChangesAsync();
            make = Mapper.Map<IVehicleMake>(mapped);
            return make;
        }

        public async Task EditAsync(IVehicleMake make)
        {
            context.Entry(Mapper.Map<VehicleMake>(make)).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            VehicleMake vehicleMake = await context.Makes.FindAsync(Id);
            context.Makes.Remove(vehicleMake);
            await context.SaveChangesAsync();
        }
    }
}


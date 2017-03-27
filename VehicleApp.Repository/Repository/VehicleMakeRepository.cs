using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class VehicleMakeRepository : Repository<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(VehicleDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<VehicleMake>> GetPage(int? page, string searchBy, string searchTerm, string sortOrder)
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
            return await model.ToListAsync();
        }
        public VehicleDbContext context
        {
            get { return base.Context as VehicleDbContext; }
        }
    }
}

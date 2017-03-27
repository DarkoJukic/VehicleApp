using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class VehicleModelRepository : Repository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(VehicleDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VehicleModel>> GetByMakeId(int MakeId)
        {
            //Need to implement paging and filtering in future
           var model = await context.Models.Where(vehicle => vehicle.VehicleMakeId == MakeId)
               .OrderBy(vehicle => vehicle.Name)
               .Take(50).ToListAsync();
            return model;
        }

        public VehicleDbContext context
        {
            get { return base.Context as VehicleDbContext; }
        }
    }
}

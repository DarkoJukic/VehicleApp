using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;

        public UnitOfWork(VehicleDbContext context)
        {
            this.context = context;
            Makes = new VehicleMakeRepository(this.context);
            Models = new VehicleModelRepository(this.context);
        }

        public IVehicleMakeRepository Makes { get; private set; }
        public IVehicleModelRepository Models { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

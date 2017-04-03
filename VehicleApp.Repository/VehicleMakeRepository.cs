using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;

namespace VehicleApp.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected Repository repository { get; private set; }

        public VehicleMakeRepository(Repository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<IVehicleMake>> GetPageAsync(int? page, string searchBy, string searchTerm, string sortOrder)
        {
            var model = Mapper.Map<IEnumerable<VehicleMakePoco>>(
                await repository.GetWhere<VehicleMake>()
                .OrderBy(k => k.Name)
                .ToListAsync());
                return model;
        }

        public async virtual Task<IVehicleMake> AddAsync(IVehicleMake make)
        {
            // make that is returned after creating.
            var returnedMake = await repository.AddAsync(Mapper.Map<VehicleMake>(make));
            return Mapper.Map<IVehicleMake>(returnedMake);
        }

        public async virtual Task<int> UpdateAsync(IVehicleMake make)
        {
            return await repository.UpdateAsync(Mapper.Map<VehicleMake>(make));
        }

        public async virtual Task<int> DeleteAsync(int id)
        {
            return await repository.DeleteAsync<VehicleMake>(id);
        }
    }
}


using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Common.Filters;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;

namespace VehicleApp.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IRepository Repository { get; private set; }

        public VehicleMakeRepository(IRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<IEnumerable<IVehicleMake>> GetPageAsync(IPagingFilter filter = null)
        {
            if (filter.SearchString != null)
            {
                var makes = Mapper.Map<IEnumerable<VehicleMakePoco>>(
                    await Repository.GetWhere<VehicleMake>()
                    .Where(r => r.Name.ToUpper().Contains(filter.SearchString.ToUpper()))
                    .OrderBy(k => k.Name)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
                return makes;
            }
            else
            {
                var makes = Mapper.Map<IEnumerable<VehicleMakePoco>>(
                    await Repository.GetWhere<VehicleMake>()
                    .OrderBy(k => k.Name)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
                return makes;
            }
        }


        public async virtual Task<IVehicleMake> AddAsync(IVehicleMake make)
        {
            // make that is returned after creating.
            var returnedMake = await Repository.AddAsync(Mapper.Map<VehicleMake>(make));
            return Mapper.Map<IVehicleMake>(returnedMake);
        }

        public async virtual Task<int> UpdateAsync(IVehicleMake make)
        {
            return await Repository.UpdateAsync(Mapper.Map<VehicleMake>(make));
        }

        public async virtual Task<int> DeleteAsync(int id)
        {
            return await Repository.DeleteAsync<VehicleMake>(id);
        }
    }
}


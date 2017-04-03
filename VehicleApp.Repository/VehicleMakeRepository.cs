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
        protected Repository repository { get; private set; }

        public VehicleMakeRepository(Repository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<IVehicleMake>> GetPageAsync(IPagingFilter filter = null)
        {
            if (filter != null)
            {
                var makes = Mapper.Map<IEnumerable<VehicleMakePoco>>(
                    await repository.GetWhere<VehicleMake>()
                    .OrderBy(k => k.Name)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    makes = makes.Where(k => k.Name.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }

                return makes;
            }
            else
            {
                return Mapper.Map<IEnumerable<VehicleMakePoco>>(await repository.GetWhere<VehicleMake>().ToListAsync());
            }

            //var model = Mapper.Map<IEnumerable<VehicleMakePoco>>(
            //    await repository.GetWhere<VehicleMake>()
            //    .OrderBy(k => k.Name)
            //    .ToListAsync());
            //    return model;
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


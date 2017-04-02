using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Models;

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

        public virtual Task<int> AddAsync(IVehicleMake make)
        {
            return repository.AddAsync(Mapper.Map<VehicleMake>(make));
        }

        public virtual Task<int> UpdateAsync(IVehicleMake make)
        {
            return repository.UpdateAsync(Mapper.Map<VehicleMake>(make));
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            return repository.DeleteAsync<VehicleMake>(id);
        }

        //public async Task<IVehicleMake> CreateAsync(IVehicleMake make)
        //{
        //    var mapped = Mapper.Map<VehicleMake>(make);

        //    context.Makes.Add(mapped);
        //    await context.SaveChangesAsync();
        //    make = Mapper.Map<IVehicleMake>(mapped);
        //    return make;
        //}

        //public async Task EditAsync(IVehicleMake make)
        //{
        //    context.Entry(Mapper.Map<VehicleMake>(make)).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int Id)
        //{
        //    VehicleMake vehicleMake = await context.Makes.FindAsync(Id);
        //    context.Makes.Remove(vehicleMake);
        //    await context.SaveChangesAsync();
        //}
    }
}


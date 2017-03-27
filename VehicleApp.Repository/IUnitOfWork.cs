using System;
using System.Threading.Tasks;
using VehicleApp.Repository.Interfaces;

namespace VehicleApp.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository Makes { get; }
        IVehicleModelRepository Models { get; }
        Task<int> SaveChangesAsync();
    }
}

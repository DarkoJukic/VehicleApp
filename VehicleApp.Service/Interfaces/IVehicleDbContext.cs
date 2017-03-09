using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Service.Models;

namespace VehicleApp.Service.Interfaces
{
    public interface IVehicleDbContext
    {
        IQueryable<VehicleMake> Makes  { get;}
        IQueryable<VehicleModel> Models { get; }
        void Save();
    }
}

using System.Data.Entity;

namespace VehicleApp.Service.Models
{
    class VehicleDbContext : DbContext
    {
        public VehicleDbContext() : base("name = VehicleDbContext") { }
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        public System.Data.Entity.DbSet<VehicleApp.Service.ViewModels.ListVehicleMakeViewModel> ListVehicleMakeViewModels { get; set; }

        public System.Data.Entity.DbSet<VehicleApp.Service.ViewModels.CreateVehicleMakeViewModel> CreateVehicleMakeViewModels { get; set; }
    }
}

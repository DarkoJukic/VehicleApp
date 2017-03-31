using System.Data.Entity;
using VehicleApp.DAL;

namespace VehicleApp.Repository.Models
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext() : base("name = VehicleDbContext") { }
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }
    }
}

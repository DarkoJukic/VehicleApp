namespace VehicleApp.Service.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleApp.Service.Models.VehicleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VehicleDbContext context)
        {
            context.Makes.AddOrUpdate(
                p => p.Name,
                new VehicleMake { Name = "Peugeot" },
                new VehicleMake { Name = "Mercedes" },
                new VehicleMake
                {
                    Name = "Renault",
                    Models = new List<VehicleModel>
                  {
                        new VehicleModel { Name = "Clio"}
                  }
                },
                new VehicleMake
                {
                    Name = "Volkswagen",
                    Abrv = "VW",
                    Models = new List<VehicleModel>
                    {
                          new VehicleModel { Name = "Golf" },
                          new VehicleModel { Name = "Passat" }
                    }
                });
        }
    }
}

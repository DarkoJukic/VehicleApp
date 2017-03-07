namespace VehicleApp.Service.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                        new VehicleModel { Model = "Clio"}
                  }
                },
                new VehicleMake
                {
                    Name = "Volkswagen",
                    Abrv = "VW",
                    Models = new List<VehicleModel>
                    {
                          new VehicleModel { Model = "Golf" },
                          new VehicleModel { Model = "Passat" }
                    }
                });
        }
    }
}

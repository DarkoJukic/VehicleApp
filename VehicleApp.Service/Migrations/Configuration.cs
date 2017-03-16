namespace VehicleApp.Repository.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleApp.Repository.Models.VehicleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VehicleDbContext context)
        {
            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j < 50; j++)
                {
                    if (i == j)
                    {
                        context.Makes.AddOrUpdate(v => v.Name,
                        new VehicleMake
                        {
                            Name = "Make" + i.ToString(),
                            Abrv = "A" + i.ToString(),
                        });
                    }
                    context.Models.AddOrUpdate(m => m.Name,
                    new VehicleModel { Name = "Model" + j.ToString(), VehicleMakeId = i, Abrv = "B" + j.ToString()});
                    Console.WriteLine(i);
                }
            };

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

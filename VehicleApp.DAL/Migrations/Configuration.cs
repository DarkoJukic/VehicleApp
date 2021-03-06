namespace VehicleApp.Repository.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleDbContext>
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
                }
            };
        }
    }
}

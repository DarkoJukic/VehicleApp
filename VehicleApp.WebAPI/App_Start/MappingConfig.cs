using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.WebAPI.ViewModels;

namespace VehicleApp.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                // VehicleMake
                config.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
                config.CreateMap<VehicleMakePoco, IVehicleMake>().ReverseMap();
                config.CreateMap<VehicleMakePoco, VehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMakeViewModel>().ReverseMap();

                // VehicleModel
                config.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
                config.CreateMap<IVehicleModel, VehicleModelViewModel>().ReverseMap();
                config.CreateMap<VehicleModelPoco, VehicleModelPoco>().ReverseMap();

            });
        }
    }
}
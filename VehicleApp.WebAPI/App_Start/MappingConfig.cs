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
                config.CreateMap<VehicleMakePoco, IVehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMakePoco>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
                config.CreateMap<VehicleMake, IVehicleMake>().ReverseMap();


                config.CreateMap<IVehicleMake, VehicleMakeViewModel>().ReverseMap();
                config.CreateMap<VehicleMakeViewModel, IVehicleMake>().ReverseMap();

                // VehicleModel
                config.CreateMap<VehicleModelPoco, VehicleModelPoco>().ReverseMap();
            });
        }
    }
}
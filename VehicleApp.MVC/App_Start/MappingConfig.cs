using VehicleApp.Service.Models;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleMake, ListVehicleMakeViewModel>();
                config.CreateMap<CreateVehicleMakeViewModel, VehicleMake>();
                config.CreateMap<VehicleMake, CreateVehicleMakeViewModel>();
            });
        }
    }
}
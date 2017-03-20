using VehicleApp.Repository.Models;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                // VehicleMake
                config.CreateMap<VehicleMake, ListVehicleMakeViewModel>();
                config.CreateMap<CreateVehicleMakeViewModel, VehicleMake>();
                config.CreateMap<VehicleMake, CreateVehicleMakeViewModel>();

                config.CreateMap<Model.VehicleMake, VehicleMake>().ReverseMap();
                config.CreateMap<Model.VehicleModel, VehicleModel>().ReverseMap();
                config.CreateMap<Model.VehicleModel, VehicleModel>();

                // VehicleModel
                config.CreateMap<VehicleModel, ListVehicleModelViewModel>();
                config.CreateMap<CreateVehicleModelViewModel, VehicleModel>();
                config.CreateMap<VehicleModel, CreateVehicleModelViewModel>();
            });
        }
    }
}
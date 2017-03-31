using VehicleApp.Model;
using VehicleApp.Service.Model.Common;
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
                config.CreateMap<Repository.Models.VehicleMake, IVehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, Repository.Models.VehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMakeViewModel>().ReverseMap();
                config.CreateMap<VehicleMakeViewModel, IVehicleMake>().ReverseMap();



                // VehicleModel
                config.CreateMap<VehicleModel, VehicleModel>().ReverseMap();
            });
        }
    }
}
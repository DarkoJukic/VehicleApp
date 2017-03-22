using VehicleApp.Model;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                // VehicleMake
                config.CreateMap<Repository.Models.VehicleMake, IVehicleMake>().ForSourceMember(x => x.Models, y => y.Ignore());

                // VehicleModel
                config.CreateMap<VehicleModel, VehicleModel>().ReverseMap();
            });
        }
    }
}
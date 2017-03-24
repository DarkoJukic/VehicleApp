using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Service.Model.Common
{
    interface IVehicleModel
    {
        int Id { get; set; }
        int VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
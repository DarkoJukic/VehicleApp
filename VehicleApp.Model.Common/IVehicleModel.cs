namespace VehicleApp.Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        int VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
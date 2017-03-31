using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApp.WebAPI.ViewModels
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
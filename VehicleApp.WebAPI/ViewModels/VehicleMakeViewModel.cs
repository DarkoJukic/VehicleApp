using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApp.Model;

namespace VehicleApp.WebAPI.ViewModels
{
    public class VehicleMakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> Models { get; set; }
    }
}
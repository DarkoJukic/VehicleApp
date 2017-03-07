using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleApp.Service;
using VehicleApp.Service.Models;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index(int MakeId)
        {
            VehicleModelService service = new VehicleModelService();
            IEnumerable<VehicleModel> model = service.Get(MakeId);
            IEnumerable<ListVehicleModelViewModel> viewModel = AutoMapper.Mapper.Map<IEnumerable<VehicleModel>, IEnumerable< ListVehicleModelViewModel>>(model);
            return View(viewModel);
        }
    }
}
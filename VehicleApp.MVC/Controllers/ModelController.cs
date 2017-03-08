using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleApp.Service;
using VehicleApp.Service.Interfaces;
using VehicleApp.Service.Models;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.Controllers
{
    public class ModelController : Controller
    {
        private readonly IVehicleModelService service;

        public ModelController(IVehicleModelService service)
        {
            this.service = service;
        }

        // GET: Model
        public ActionResult Index(int Id)
        {
            IEnumerable<VehicleModel> model = service.Get(Id);
            IEnumerable<ListVehicleModelViewModel> viewModel = AutoMapper.Mapper.Map<IEnumerable<VehicleModel>, IEnumerable< ListVehicleModelViewModel>>(model);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Create(int Id)
        {
            CreateVehicleModelViewModel model = new CreateVehicleModelViewModel();
            model.VehicleMakeId = Id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleModelViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                VehicleModel model = AutoMapper.Mapper.Map<CreateVehicleModelViewModel, VehicleModel>(viewModel);
                service.Create(model);
                return RedirectToAction("Index", new { Id = model.VehicleMakeId});
            }
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = service.Edit(Id);
            var viewModel = AutoMapper.Mapper.Map<VehicleModel, CreateVehicleModelViewModel>(model);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(CreateVehicleModelViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                var model = AutoMapper.Mapper.Map<CreateVehicleModelViewModel, VehicleModel>(viewModel);
                service.Edit(model);
                return RedirectToAction("Index", new { Id = model.VehicleMakeId });
            }
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = service.Delete(Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            service.DeleteConfirmed(Id);
            return RedirectToAction("Index", "Make");
        }
    }
}
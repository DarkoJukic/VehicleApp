using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VehicleApp.Service.Interfaces;
using VehicleApp.Service.Models;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.Controllers
{
    public class MakeController : Controller
    {
        private readonly IVehicleMakeService service;

        public MakeController(IVehicleMakeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index(int? page, string sortOrder, string searchTerm = null)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            ViewBag.DateSortParm = sortOrder == "Abrv" ? "AbrvDesc" : "Abrv";

            List<VehicleMake> model = service.Get(page, searchTerm, sortOrder);
            IEnumerable<ListVehicleMakeViewModel> viewModel = AutoMapper.Mapper.Map<List<VehicleMake>, IEnumerable<ListVehicleMakeViewModel>>(model);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(viewModel.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleMakeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                VehicleMake model = AutoMapper.Mapper.Map<CreateVehicleMakeViewModel, VehicleMake>(viewModel);
                service.Create(model);
                return RedirectToAction("Index");
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
            var viewModel = AutoMapper.Mapper.Map<VehicleMake, CreateVehicleMakeViewModel>(model);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CreateVehicleMakeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                var model = AutoMapper.Mapper.Map<CreateVehicleMakeViewModel, VehicleMake>(viewModel);
                service.Edit(model);
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
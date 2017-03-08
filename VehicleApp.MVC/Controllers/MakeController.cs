﻿using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VehicleApp.Service;
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
        public ActionResult Index()
        {
            List<VehicleMake> model = service.Get();
            IEnumerable<ListVehicleMakeViewModel> viewModel = AutoMapper.Mapper.Map<List<VehicleMake>, IEnumerable<ListVehicleMakeViewModel>>(model);
            return View(viewModel);
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
            VehicleMakeService service = new VehicleMakeService();
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
            VehicleMakeService service = new VehicleMakeService();
            service.DeleteConfirmed(Id);
            return RedirectToAction("Index");
        }
    }
}
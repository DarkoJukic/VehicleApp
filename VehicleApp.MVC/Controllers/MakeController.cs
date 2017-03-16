using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleApp.Repository;
using VehicleApp.Repository.Models;
using VehicleApp.Service;
using VehicleApp.Service.Common;
using VehicleApp.Service.ViewModels;

namespace VehicleApp.MVC.Controllers
{
    public class MakeController : Controller
    {
        private readonly IVehicleMakeService service;

        public MakeController(VehicleMakeService service)
        {
            this.service = new VehicleMakeService(new VehicleMakeRepository(new VehicleDbContext()));
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? page, string sortOrder, string searchBy, string searchTerm = null)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            ViewBag.DateSortParm = sortOrder == "Abrv" ? "AbrvDesc" : "Abrv";
            List<VehicleMake> model = await service.GetAllVehicleMakes(page, searchBy, searchTerm, sortOrder);
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
                service.CreateVehicleMake(model);
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
            var model = service.EditVehicleMake(Id);
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
                service.EditVehicleMake(model);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = service.DeleteVehicleMake(Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            service.DeleteVehicleMakeConfirmed(Id);
            return RedirectToAction("Index");
        }
    }
}
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VehicleApp.Model;
using VehicleApp.Service;
using VehicleApp.Service.Common;

namespace VehicleApp.MVC.Controllers
{
    public class MakesController : ApiController
    {
        private readonly IVehicleMakeService service;

        public MakesController(VehicleMakeService service)
        {
            this.service = service;
        }

        // GET: api/Makes
        public async Task<List<VehicleApp.Repository.Models.VehicleMake>> Get()
        {
            return await service.GetAllVehicleMakes(1, null, null, null);
        }


        // POST: api/Makes
        public HttpResponseMessage Post([FromBody]VehicleMake vehicle)
        {
            var mappedVehicle = Mapper.Map<VehicleApp.Repository.Models.VehicleMake>(vehicle); 

            service.CreateVehicleMake(mappedVehicle);

            return Request.CreateResponse(HttpStatusCode.Created, vehicle);
        }

        // PUT: api/Makes/5
        public void Put(int id, [FromBody]VehicleMake vehicle)
        {
            var mappedVehicle = Mapper.Map<VehicleApp.Repository.Models.VehicleMake>(vehicle);
            service.EditVehicleMake(mappedVehicle);
        }

        // DELETE: api/Makes/5
        public void Delete(int id)
        {
            service.DeleteVehicleMakeConfirmed(id);
        }
    }
}

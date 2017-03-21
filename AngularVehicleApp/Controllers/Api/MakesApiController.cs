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

        // GET: api/makes
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await service.GetAllVehicleMakes(1, null, null, null));
        }


        // POST: api/makes
        public IHttpActionResult Post([FromBody]VehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var mappedVehicle = Mapper.Map<VehicleApp.Repository.Models.VehicleMake>(vehicle); 

            service.CreateVehicleMake(mappedVehicle);

            // if save is not successfull
            //if (createdVehicle == null)
            //{
            //    return Conflict();
            //}

            return Created(Request.RequestUri + mappedVehicle.ToString(), mappedVehicle);
        }

        // PUT: api/makes/5
        public IHttpActionResult Put(int id, [FromBody]VehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var mappedVehicle = Mapper.Map<VehicleApp.Repository.Models.VehicleMake>(vehicle);

            if (mappedVehicle == null)
            {
                return NotFound();
            }
            service.EditVehicleMake(mappedVehicle);
            return Ok();
        }

        // DELETE: api/makes/5
        public IHttpActionResult Delete(int id)
        {
            service.DeleteVehicleMakeConfirmed(id);
            return Ok();
            //if exists
            //if (status)
            //{
            //    //return new HttpResponseMessage(HttpStatusCode.OK);
            //    return Ok();
            //}
            //else
            //{
            //    //throw new HttpResponseException(HttpStatusCode.NotFound);
            //    return NotFound();
            //}

        }
    }
}

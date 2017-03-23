using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleApp.Model;
using VehicleApp.Service.Common;
using VehicleApp.Service.Model.Common;

namespace VehicleApp.MVC.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class MakesController : ApiController
    {
        private readonly IVehicleMakeService service;

        public MakesController(IVehicleMakeService service)
        {
            this.service = service;
        }

        // GET: api/makes
        public async Task<IHttpActionResult> Get()
        {
            // currently hardcoded
            List<Repository.Models.VehicleMake> makes = await service.GetAllVehicleMakes(1, null, null, null);

            List<IVehicleMake> mappedMakes= Mapper.Map<List<IVehicleMake>>(makes);

            return Ok(mappedMakes);
        }


        // POST: api/makes
        public async Task<IHttpActionResult> Post([FromBody]VehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var mappedVehicle = Mapper.Map<Repository.Models.VehicleMake>(vehicle);

            await service.CreateVehicleMake(mappedVehicle);

            //if save is not successfull
            if (mappedVehicle == null)
            {
                return Conflict();
            }

            return Created(Request.RequestUri + mappedVehicle.ToString(), mappedVehicle);
        }

        // PUT: api/makes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]VehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var mappedVehicle = Mapper.Map<Repository.Models.VehicleMake>(vehicle);

            if (mappedVehicle == null)
            {
                return NotFound();
            }
            await service.EditVehicleMake(mappedVehicle);
            return Ok();
        }

        // DELETE: api/makes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await service.DeleteVehicleMakeConfirmed(id);
            return Ok();
        }
    }
}
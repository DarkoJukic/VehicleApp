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
    [EnableCors("*", "*", "*")]
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
            // currently hardcoded values for paging, filtering, sorting and ordering
            List<Repository.Models.VehicleMake> makes = await service.GetAllVehicleMakes(1, null, null, null);

            List<IVehicleMake> mappedMakes = Mapper.Map<List<IVehicleMake>>(makes);

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

            return Created(Request.RequestUri + mappedVehicle.ToString(), mappedVehicle);
        }

        // PUT: api/makes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]VehicleMake vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data not entered");
            }
            // map to entity model
            var mappedVehicle = Mapper.Map<Repository.Models.VehicleMake>(vehicle);
            // edit 
            await service.EditVehicleMake(mappedVehicle);

            if (mappedVehicle == null)
            {
                return NotFound();
            }

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
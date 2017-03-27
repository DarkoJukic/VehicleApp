using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleApp.Model;
using VehicleApp.Service.Common;

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
            IEnumerable<VehicleApp.Repository.Models.VehicleMake> makes = await service.GetPage(1, null, null, null);
            return Ok(makes);
        }

        //POST: api/makes
        public async Task<IHttpActionResult> Post([FromBody]VehicleMake make)
        {
            if (make == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            // map to entity model
            var mappedMake = Mapper.Map<Repository.Models.VehicleMake>(make);

            await service.CreateMake(mappedMake);

            return Created(Request.RequestUri + mappedMake.ToString(), mappedMake);
        }

        // PUT: api/makes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]VehicleMake make)
        {
            if (make == null)
            {
                return BadRequest("Vehicle data not entered");
            }
            // map to entity model
            var mappedMake = Mapper.Map<Repository.Models.VehicleMake>(make);
            // edit 
            await service.EditMake(mappedMake);

            if (mappedMake == null)
            {
                return NotFound();
            }

            return Ok();
        }

        //DELETE: api/makes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await service.DeleteMake(id);
            return Ok();
        }
    }
}
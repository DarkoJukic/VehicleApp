using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleApp.Model;
using VehicleApp.Service.Common;
using VehicleApp.Model.Common;
using VehicleApp.WebAPI.ViewModels;

namespace VehicleApp.MVC.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MakesController : ApiController
    {
        private readonly IVehicleMakeService Service;

        public MakesController(IVehicleMakeService service)
        {
            this.Service = service;
        }

        // GET: api/makes
        public async Task<IHttpActionResult> Get()
        {
            // currently hardcoded values for paging, filtering, sorting and ordering
            var makes =  Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await Service.GetPage(1, null, null, null));           
            return Ok(makes);
        }

        //POST: api/makes
        public async Task<IHttpActionResult> Post([FromBody]VehicleMakeViewModel make)
        {
            if (make == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var createdMakeWithId = await Service.CreateMake(Mapper.Map<IVehicleMake>(make));

            return Created(Request.RequestUri + make.ToString(), createdMakeWithId);
        }

        // PUT: api/makes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]VehicleMakeViewModel make)
        {
            if (make == null)
            {
                return BadRequest("Vehicle data not entered");
            }
            await Service.EditMake(Mapper.Map<IVehicleMake>(make));
            return Ok();
        }

        //DELETE: api/makes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Service.DeleteMake(id);
            return Ok();
        }
    }
}
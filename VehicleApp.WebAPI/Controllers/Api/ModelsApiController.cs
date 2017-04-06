using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Service.Service.Common;
using VehicleApp.WebAPI.ViewModels;

namespace VehicleApp.MVC.Controllers.Api
{
    [EnableCors("*", "*", "*")]
    public class ModelsController : ApiController
    {

        private readonly IVehicleModelService Service;

        public ModelsController(IVehicleModelService service)
        {
            this.Service = service;
        }

        public async Task<IHttpActionResult> GetModelsByMakeId(int Id)
        {
            var model = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await Service.GetModelsByMakeId(Id));
            return Ok(model);
        }


        //POST: api/models
        public async Task<IHttpActionResult> Post([FromBody]VehicleModelViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var createdModelWithId = await Service.CreateModel(Mapper.Map<IVehicleModel>(model));

            return Created(Request.RequestUri + model.ToString(), Mapper.Map<VehicleModelViewModel>(createdModelWithId));
        }

        // PUT: api/models/:id
        public async Task<IHttpActionResult> Put(int id, [FromBody]VehicleModelViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Vehicle data not entered");
            }
            await Service.EditModel(Mapper.Map<IVehicleModel>(model));
            return Ok();
        }

        //DELETE: api/models/:id
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Service.DeleteModel(id);
            return Ok();
        }
    }
}

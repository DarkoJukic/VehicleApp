using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleApp.Model;
using VehicleApp.Service.Service.Common;

namespace VehicleApp.MVC.Controllers.Api
{
    [EnableCorsAttribute("*", "*", "*")]
    public class ModelsController : ApiController
    {

        private readonly IVehicleModelService Service;

        public ModelsController(IVehicleModelService service)
        {
            this.Service = service;
        }

        //public async Task<IEnumerable<VehicleApp.Repository.Models.VehicleModel>> GetModelsByMakeId(int Id)
        //{
        //    return await Service.GetModelsByMakeId(Id);
        //}

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}

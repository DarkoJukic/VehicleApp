using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VehicleApp.Model;
using VehicleApp.Repository.Interfaces;
using VehicleApp.Service.Service.Common;

namespace VehicleApp.MVC.Controllers.Api
{
    public class ModelsController : ApiController
    {

        private readonly IVehicleModelService service;

        public ModelsController(IVehicleModelService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<VehicleApp.Repository.Models.VehicleModel>> GetModelsByMakeId(int Id)
        {
            return await service.GetModelsByMakeId(Id);
        }

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

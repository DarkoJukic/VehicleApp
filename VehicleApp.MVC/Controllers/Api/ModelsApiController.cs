using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VehicleApp.MVC.Controllers.Api
{
    public class Modelsontroller : ApiController
    {
        public int Get(int MakeId)
        {
            return MakeId;
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

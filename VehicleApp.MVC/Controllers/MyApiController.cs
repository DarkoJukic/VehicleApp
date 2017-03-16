using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VehicleApp.MVC.Controllers
{
    public class MyApiController : ApiController
    {
        // GET: api/Api
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Api/5
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST: api/Api
        public void Post([FromBody]string value)
        {
            return;
        }

        // PUT: api/Api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }
    }
}

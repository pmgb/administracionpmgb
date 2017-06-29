using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carrentalweb.Controllers
{
    public class otro_pmController : ApiController
    {
        // GET: api/otro_pm
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/otro_pm/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/otro_pm
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/otro_pm/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/otro_pm/5
        public void Delete(int id)
        {
        }
    }
}

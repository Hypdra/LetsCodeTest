using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestFilipa.Models;

namespace TestFilipa.Controllers
{
    public class TescikController : ApiController
    {
        // GET: api/Tescik
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tescik/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tescik
        public ReservationRequest Post([FromBody]ReservationRequest value)
        {
            value.NumberOfPersons ++;
            return value;
        }

        // PUT: api/Tescik/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tescik/5
        public void Delete(int id)
        {
        }
    }
}

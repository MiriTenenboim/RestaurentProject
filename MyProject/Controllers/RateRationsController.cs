using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using System.Web.Http.Cors;

namespace MyProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RateRationsController : ApiController
    {
        // GET: api/RateRations/GetAllRateRations
        public List<RateRationsDTO> GetAllRateRations()
        {
            return RateRationsBLL.GetAllRateRations();
        }

        // GET: api/RateRations/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST: api/RateRations/AddRateRation
        [Route("api/RateRations/AddRateRation")]
        public RateRationsDTO AddRateRation([FromBody] List<dynamic> rateRation)
        {
            RateRationsDTO rate = rateRation[0].ToObject<RateRationsDTO>();
            var numberPhoneClient = (string)rateRation[3];
            var nameRation = (string)rateRation[2];
            var nameClient = (string)rateRation[1];
           return RateRationsBLL.AddRateRation(rate, nameClient,nameRation,numberPhoneClient);
        }

        // PUT: api/RateRations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RateRations/5
        public void Delete(int id)
        {
        }
    }
}

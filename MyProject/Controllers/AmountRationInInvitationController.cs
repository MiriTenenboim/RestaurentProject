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
    public class AmountRationInInvitationController : ApiController
    {
        // GET: api/AmountRationInInvitation
        [HttpGet]
        [Route("api/AmountRationInInvitation/GetAllAmounts")]
        public List<AmountRationInInvitationDTO> GetAllAmounts()
        {
            return AmountRationInInvitationBLL.GetAllAmounts();
        }

        // GET: api/AmountRationInInvitation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AmountRationInInvitation
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        // PUT: api/AmountRationInInvitation/5
        [Route("api/AmountRationInInvitation/{codeRation}")]
        public bool AddAmountToRation(int codeRation)
        {
            return AmountRationInInvitationBLL.AddAmountToRation(codeRation);
        }

        // DELETE: api/AmountRationInInvitation/5
        public void Delete(int id)
        {
        }
    }
}

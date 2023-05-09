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
    public class RationInInvitationController : ApiController
    {
        [HttpGet]
        // GET: api/RationInInvitation/GetAllRationInInvations
        [Route("api/RationInInvitation/GetAllRationInInvation/{codeInvitation}")]
        public List<RationsDTO> GetAllRationInInvation(int codeInvitation)
        {
            return RationInInvationBLL.GetAllRationInInvation(codeInvitation);
        }

        [Route("api/RationInInvitation/GetRationInInvationsThatPerformed")]
        // GET: api/RationInInvitation/GetRationInInvationsThatPerformed
        public List<RationInInvationDTO> GetRationInInvationsThatNotPerformed()
        {
            return RationInInvationBLL.GetRationInInvationsThatNotPerformed();
        }

        [Route("api/RationInInvitation/GetAllRationsByCode/{codeInvitation}")]
        // GET: api/RationInInvitation/5
        public List<RationInInvationDTO> GetAllRationsByCode(int codeInvitation)
        {
            return RationInInvationBLL.GetAllRationsByCode(codeInvitation);
        }

        [Route("api/RationInInvitation/GetPricePerServing/{codeInvitation}/{codeRation}")]
        // GET: api/RationInInvitation/5
        public decimal GetPricePerServing(int codeInvitation,int codeRation)
        {
            return RationInInvationBLL.GetPricePerServing(codeInvitation,codeRation);
        }

        [Route("api/RationInInvitation/GetAmountRation/{nameRation}")]
        // GET: api/RationInInvitation/5
        public int GetAmountRation(string nameRation)
        {
            return RationInInvationBLL.GetAmountRation(nameRation);
        }

        // POST: api/RationInInvitation/AddRationInInvation
        [HttpPost]
        [Route("api/RationInInvitation/AddRationInInvation")]
        public RationInInvationDTO AddRationInInvation([FromBody] List<dynamic> rationInInvitation)
        {
            RationInInvationDTO RationInInvitation = rationInInvitation[0].ToObject<RationInInvationDTO>();
            var nameRation = rationInInvitation[1];
            return RationInInvationBLL.AddRationInInvation(RationInInvitation,nameRation);
        }

        // PUT: api/RationInInvitation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE: api/RationInInvitation/RationInInvitation/DeleteRationInInvitation/{codeInvitation}/{nameRation}
        [Route("api/RationInInvitation/DeleteRationInInvitation/{codeInvitation}/{nameRation}")]
        public bool DeleteRationInInvitation(int codeInvitation,string nameRation)
        {
            return RationInInvationBLL.DeleteRationInInvitation(codeInvitation,nameRation);
        }
    }
}

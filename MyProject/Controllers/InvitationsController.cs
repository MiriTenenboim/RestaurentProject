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
    public class InvitationsController : ApiController
    {
        [HttpGet]
        // GET: api/Invitations/GetAllInvitations
        [Route("api/Invitations/GetAllInvitations")]
        public List<InvationsDTO> GetAllInvitations()
        {
            return InvationsBLL.GetAllInvitations();
        }

        // GET: api/Invitations/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invitations/AddInvitation
        [HttpPost]
        [Route("api/Invitations/AddInvitation")]
        public int AddInvitation([FromBody]List<dynamic> invitation)
        {
            var NameClient = invitation[0];
            var PhoneClient = invitation[1];
            return InvationsBLL.AddInvitation(NameClient,PhoneClient);
        }

        [HttpPut]
        [Route("api/Invitations/UpdateInvitationToPaid/{codeInvitation}")]
        // PUT: api/Invitations/5
        public bool UpdateInvitationToPaid(int codeInvitation)
        {
            return InvationsBLL.UpdateInvitationToPaid(codeInvitation);
        }

        [HttpPut]
        [Route("api/Invitations/UpdatePriceToPay/{codeInvitation}/{price}")]
        // PUT: api/Invitations/5
        public bool UpdatePriceToPay(int codeInvitation,int price)
        {
            return InvationsBLL.UpdatePriceToPay(codeInvitation, price);
        }

        // DELETE: api/Invitations/5
        public void Delete(int id)
        {
        }
    }
}

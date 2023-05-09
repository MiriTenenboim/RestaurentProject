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
    public class InvitationInTableController : ApiController
    {
        [HttpGet]
        [Route("api/InvitationInTable/GetAllInvitationInTables")]
        // GET: api/InvitationInTable/GetAllInvitationInTables
        public List<InvitationInTableDTO> GetAllInvitationInTables()
        {
            return InvationInTableBLL.GetAllInvationInTables();
        }

        // GET: api/InvitationInTable/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST: api/InvitationInTable
        [Route("api/InvitationInTable/AddInvationInTable/{codeInvitation}/{tableLocation}")]
        public bool AddInvationInTable(int codeInvitation, string tableLocation)
        {
            return InvationInTableBLL.AddInvationInTable(codeInvitation, tableLocation);
        }

        [HttpPut]
        // PUT: api/InvitationInTable/UpdateTableToEmpty
        [Route("api/InvitationInTable/UpdateTableToEmpty/{tableLocation}")]
        public bool UpdateTableToEmpty(string tableLocation)
        {
            return InvationInTableBLL.UpdateTableToEmpty(tableLocation);
        }

        // DELETE: api/InvitationInTable/5
        public void Delete(int id)
        {
        }
    }
}

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
    public class ClientsController : ApiController
    {
        [HttpGet]
        [Route("api/Clients/GetAllClients")]
        // GET: api/Clients/GetAllClients
        public List<ClientsDTO> GetAllClients()
        {
            return ClientsBLL.GetAllClients();
        }

        [Route("api/Clients/GetClientByNamePhone/{name}/{phone}")]
        // GET: api/Clients/GetClientByNamePhone/name/phone
        public ClientsDTO GetClientByNamePhone(string name, string phone)
        {
            return ClientsBLL.GetClientByNamePhone(name, phone);
        }

        // GET: api/Clients/GetClientById/id
        //public ClientsDTO GetClientById(int id)
        //{
        //    return ClientsBLL.GetClientById(id);
        //}

        // POST: api/Clients/AddClient
        [HttpPost]
        [Route("api/Clients/AddClient")]
        public ClientsDTO AddClient([FromBody] List<dynamic> client)
        {
            var nameClient = client[0];
            var familyClient = client[1];
            var telClient = client[2];
            var emailClient = client[3];
            return ClientsBLL.AddClient(nameClient, familyClient, telClient, emailClient);
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
        }
    }
}

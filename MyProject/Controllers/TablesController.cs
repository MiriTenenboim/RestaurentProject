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
    public class TablesController : ApiController
    {
        [HttpGet]
        // GET: api/Tables/GetAllTables
        [Route("api/Tables/GetAllTables")]
        public List<TablesDTO> GetAllTables()
        {
            return TablesBLL.GetAllTables();
        }

        [Route("api/Tables/GetTablesByNumDiners/{min}/{max}")]
        public List<TablesDTO> GetTablesByNumDiners(int min, int max)
        {
            return TablesBLL.GetTablesByNumDiners(min, max);
        }

        // GET: api/Tables/GetBusyLocation
        [Route("api/Tables/GetBusyLocation")]
        public List<string> GetBusyLocation()
        {
            return TablesBLL.GetBusyLocation();
        }

        [Route("api/Tables/GetFreeLocation")]
        public List<string> GetFreeLocation()
        {
            return TablesBLL.GetFreeLocation();
        }

        // GET: api/Tables/GetTableByLocation/location
        [Route("api/Tables/GetTableByLocation/{location}")]
        public List<TablesDTO> GetTableByLocation(string location)
        {
            return TablesBLL.GetTableByLocation(location);
        }

        // GET: api/Tables/GetFreeTables
        [Route("api/Tables/GetFreeTables")]
        public List<TablesDTO> GetFreeTables()
        {
            return TablesBLL.GetFreeTables();
        }

        [HttpPost]
        // POST: api/Tables
        [Route("api/Tables/AddTable")]
        public bool AddTable([FromBody] List<dynamic> table)
        {
            var tableLocation = (string)table[2];
            var numDiners = int.Parse(table[1]);
            return TablesBLL.AddTable(tableLocation, numDiners);
        }

        // PUT: api/Tables/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tables/5
        public void Delete(int id)
        {
        }
    }
}

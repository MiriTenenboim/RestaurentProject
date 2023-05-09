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
    public class RationsController : ApiController
    {
        [HttpGet]
        // GET: api/Rations
        //שליפת כל המנות
        [Route("api/Rations/GetAllRations")]
        public List<RationsDTO> GetAllRations()
        {
            return RationsBLL.GetAllRations();
        }

        //שליפת מנות לפי קטגוריה
        [Route("api/Rations/GetRationsByCategory/{name}")]
        public List<RationsDTO> GetRationsByCategory(string name)
        {
            return RationsBLL.GetRationsByCategory(name);
        }

        //שליפת מנה לפי שם מנה
        [Route("api/Rations/GetRationsByNameRations/{name}")]
        public List<RationsDTO> GetRationsByNameRations(string name)
        {
            return RationsBLL.GetRationsByNameRations(name);
        }

        //שליפת שמות המנות
        [Route("api/Rations/GetNameRations")]
        public List<string> GetNameRations()
        {
            return RationsBLL.GetNameRations();
        }

        //שליפת המנה לפי קוד
        [Route("api/Rations/GetRationsByCode/{code}")]
        public RationsDTO GetRationsByCode(int code)
        {
            return RationsBLL.GetRationsByCode(code);
        }

        //שליפת המנה בטווח נקודות
        [Route("api/Rations/GetAllRationsByScoreOfRationsBetween/{start}/{finish}")]
        public List<RationsDTO> GetAllRationsByScoreOfRationsBetween(int start, int finish)
        {
            return RationsBLL.GetAllRationsByScoreOfRationsBetween(start, finish);
        }

        //שליפת המנה בטווח מחירים
        [Route("api/Rations/GetAllRationsByPriceOfRationsBetween/{start}/{finish}")]
        public List<RationsDTO> GetAllRationsByPriceOfRationsBetween(int start, int finish)
        {
            return RationsBLL.GetAllRationsByPriceOfRationsBetween(start, finish);
        }

        //שליפת המנה לפי חלבי או פרווה
        [Route("api/Rations/GetRationsByDairyOrNot/{isDairy}")]
        public List<RationsDTO> GetRationsByDairyOrNot(bool isDairy)
        {
            return RationsBLL.GetRationsByDairyOrNot(isDairy);
        }

        //שליפת קוד מנה לפי שם המנה
        [Route("api/Rations/GetCodeRationsByName/{nameRation}")]
        public int GetCodeRationsByName(string nameRation)
        {
            return RationsBLL.GetCodeRationsByName(nameRation);
        }

        [HttpPost]
        // POST: api/Rations
        [Route("api/Rations/AddRation")]
        public bool AddRation([FromBody] List<dynamic> ration)
        {
            RationsDTO Ration = ration[0].ToObject<RationsDTO>();
            var dairyOrNot = (string)ration[2];
            var nameCategory = (string)ration[1];
            return RationsBLL.AddRation(Ration, nameCategory, dairyOrNot);
        }

        [HttpPut]
        [Route("api/Rations/UpdateAmountRation/{nameRation}/{plus}")]
        // PUT: api/Rations/UpdateAmountRation/{nameRation}/{plus}
        public bool UpdateAmountRation(string nameRation, int plus)
        {
            return RationsBLL.UpdateAmountRation(nameRation, plus);
        }

        [HttpPut]   
        [Route("api/Rations/UpdateAmount/{nameRation}")]
        // PUT: api/Rations/UpdateAmount/{nameRation}
        public bool UpdateAmount(string nameRation)
        {
            return RationsBLL.UpdateAmount(nameRation);
        }

        // DELETE: api/Rations/5
        public void Delete(int id)
        {
        }
    }
}

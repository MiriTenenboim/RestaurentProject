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
    public class FoodCategoryController : ApiController
    {
        [HttpGet]
        [Route("api/FoodCategory/GetAllCategories")]
        // GET: api/FoodCategory/GetAllCategories
        public List<string> GetAllCategories()
        {
            return FoodCategoryBLL.GetAllFoodCategory();
        }

        [Route("api/FoodCategory/GetFoodCategoryByCode/{code}")]
        // GET: api/FoodCategory/GetFoodCategoryByCode/code
        public FoodCategoryDTO GetFoodCategoryByCode(int code)
        {
            return FoodCategoryBLL.GetFoodCategoryByCode(code);
        }

        [HttpPost]
        // POST: api/FoodCategory/AddFoodCategory
        [Route("api/FoodCategory/AddFoodCategory")]
        public bool AddFoodCategory([FromBody] List<dynamic> foodCategory)
        {
            return FoodCategoryBLL.AddFoodCategory(foodCategory[0]);
        }

        // PUT: api/FoodCategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FoodCategory/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RateRationsDAL
    {
        //הוספת דרוג למנה
        public static bool AddRateRation(RateRations rateRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.RateRations.Add(rateRation);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
        //שליפת כל הדרוגים
        public static List<RateRations> GetAllRateRations()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RateRations.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodCategoryDAL
    {
        //הוספת קטגוריה חדשה
        public static bool AddFoodCategory(FoodCategory foodCategory)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.FoodCategory.Add(foodCategory);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
        //שליפת כל הקטגוריות
        public static List<string> GetAllFoodCategory()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    List<string> answer = new List<string>();
                    var temp = DB.FoodCategory.ToList();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        answer.Add(temp[i].NameCategory);
                    }
                    return answer;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת שם קטגוריה לפי קוד
        public static FoodCategory GetFoodCategoryByCode(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.FoodCategory.FirstOrDefault(id => id.CodeCategory == code);
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד קטגוריה לפי שם
        public static int GetCodeFoodCategoryByName(string name)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.FoodCategory.FirstOrDefault(id => id.NameCategory == name);
                    if (temp!=null)
                    {
                        return temp.CodeCategory;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}
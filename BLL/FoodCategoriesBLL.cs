using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class FoodCategoryBLL
    {
        //הוספת קטגוריה חדשה
        public static bool AddFoodCategory(string nameCategory)
        {
            try
            {
                var codeCategory = GetCodeFoodCategoryByName(nameCategory);
                if (codeCategory == 0)
                {
                    FoodCategoryDTO newCategory = new FoodCategoryDTO();
                    newCategory.NameCategory = nameCategory;
                    FoodCategoryDAL.AddFoodCategory(FoodCategoryDTO.ConvertFoodCategoryToTable(newCategory));
                }
                return true;
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
                return FoodCategoryDAL.GetAllFoodCategory();
            }
            catch (Exception error)
            {
                return null;
            }

        }

        //שליפת שם קטגוריה לפי קוד
        public static FoodCategoryDTO GetFoodCategoryByCode(int code)
        {
            try
            {
                return FoodCategoryDTO.ConvertFoodCategoryToDTO(FoodCategoryDAL.GetFoodCategoryByCode(code));
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
                return FoodCategoryDAL.GetCodeFoodCategoryByName(name);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}

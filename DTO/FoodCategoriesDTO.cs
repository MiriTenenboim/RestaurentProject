using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class FoodCategoryDTO
    {
        public int CodeCategory { get; set; }
        public string NameCategory { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static FoodCategory ConvertFoodCategoryToTable(FoodCategoryDTO foodCategory)
        {
            FoodCategory newfoodCategory = new FoodCategory();
            try
            {
                newfoodCategory.CodeCategory = foodCategory.CodeCategory;
                newfoodCategory.NameCategory = foodCategory.NameCategory;
                return newfoodCategory;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<FoodCategory> ConvertFoodCategoryListToTable(List<FoodCategoryDTO> FoodCategory)
        {
            List<FoodCategory> newFoodCategory = new List<FoodCategory>();
            try
            {
                foreach (var foodCategory in FoodCategory)
                {
                    newFoodCategory.Add(ConvertFoodCategoryToTable(foodCategory));
                }
                return newFoodCategory;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static FoodCategoryDTO ConvertFoodCategoryToDTO(FoodCategory foodCategory)
        {
            FoodCategoryDTO newfoodCategory = new FoodCategoryDTO();
            try
            {
                newfoodCategory.CodeCategory = foodCategory.CodeCategory;
                newfoodCategory.NameCategory = foodCategory.NameCategory;
                return newfoodCategory;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<FoodCategoryDTO> ConvertFoodCategoryListToDTO(List<FoodCategory> FoodCategory)
        {
            List<FoodCategoryDTO> newFoodCategory = new List<FoodCategoryDTO>();
            try
            {
                foreach (var foodCategory in FoodCategory)
                {
                    newFoodCategory.Add(ConvertFoodCategoryToDTO(foodCategory));
                }
                return newFoodCategory;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RationsBLL
    {
        //הוספת מנה
        public static bool AddRation(RationsDTO ration, string nameCategory, string dairyOrNot)
        {
            try
            {
                var codeRation = GetCodeRationsByName(ration.NameRation);
                ration.CodeRation = codeRation;

                var codeCategory = FoodCategoryBLL.GetCodeFoodCategoryByName(nameCategory);
                if (codeCategory == 0)
                {
                    FoodCategoryBLL.AddFoodCategory(nameCategory);
                    codeCategory = FoodCategoryBLL.GetCodeFoodCategoryByName(nameCategory);
                    return false;
                }
                if (dairyOrNot == "חלבי")
                {
                    ration.DairyOrNot = true;
                }
                else
                {
                    ration.DairyOrNot = false;
                }
                ration.CodeCategory = codeCategory;
                ration.DateUpdateAmount = DateTime.Today.Date;
                //אם המנה לא קיימת - מוסיפים אותה
                if (codeRation == 0)
                {
                    RationsDAL.AddRation(RationsDTO.ConvertRationToTable(ration));
                    return true;
                }
                //אם המנה קיימת - מעדכנים את הפרטים
                return UpdateRation(ration);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון פרטי המנה
        public static bool UpdateScoreOfRation(int codeRation, int scoreOfRation)
        {
            try
            {
                var amount = AmountRationInInvitationBLL.GetAmountRationByCode(codeRation);
                var newScore = GetScoreRation(codeRation);
                newScore *= amount;
                newScore += scoreOfRation;
                newScore /= (amount + 1);
                return RationsDAL.UpdateScoreOfRation(codeRation, newScore);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון פרטי המנה
        public static bool UpdateAmountRation(string nameRation, int plus)
        {
            try
            {
                var codeRation = GetCodeRationsByName(nameRation);
                return RationsDAL.UpdateAmountRation(codeRation, plus);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static bool UpdateAmount(string nameRation)
        {
            try
            {
                var codeRation = GetCodeRationsByName(nameRation);
                return RationsDAL.UpdateAmount(codeRation);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון פרטי המנה
        public static bool UpdateRation(RationsDTO ration)
        {
            try
            {
                return RationsDAL.UpdateRation(RationsDTO.ConvertRationToTable(ration));
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל המנות
        public static List<RationsDTO> GetAllRations()
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetAllRations());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת שמות המנות
        public static List<string> GetNameRations()
        {
            try
            {
                return RationsDAL.GetNameRations();
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מספר נקודות הדרוג של מנה
        public static int GetScoreRation(int codeRation)
        {
            try
            {
                return RationsDAL.GetScoreRation(codeRation);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת כל המנות שמספר נקודות הדרוג שלהם בין 2 המספרים שנקלטו
        public static List<RationsDTO> GetAllRationsByScoreOfRationsBetween(int start, int finish)
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetAllRationsByScoreOfRationsBetween(start, finish));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כל המנות שמחירם בין 2 המספרים שנקלטו
        public static List<RationsDTO> GetAllRationsByPriceOfRationsBetween(int start, int finish)
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetAllRationsByPriceOfRationsBetween(start, finish));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מנות לפי שם קטגוריה
        public static List<RationsDTO> GetRationsByCategory(string name)
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetRationsByCategory(name));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מנה לפי שם המנה
        public static List<RationsDTO> GetRationsByNameRations(string name)
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetRationsByNameRations(name));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מחיר מנה לפי קוד מנה
        public static decimal GetPriceOfRationsByCode(int code)
        {
            try
            {
                return RationsDAL.GetPriceOfRationsByCode(code);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת מנה לפי קוד מנה
        public static RationsDTO GetRationsByCode(int code)
        {
            try
            {
                return RationsDTO.ConvertRationToDTO(RationsDAL.GetRationsByCode(code));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד מנה לפי שם מנה
        public static int GetCodeRationsByName(string name)
        {
            try
            {
                return RationsDAL.GetCodeRationByName(name);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת מנה לפי חלבי או פרווה
        public static List<RationsDTO> GetRationsByDairyOrNot(bool isDairy)
        {
            try
            {
                return RationsDTO.ConvertRationListToDTO(RationsDAL.GetRationsByDairyOrNot(isDairy));
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RationsDAL
    {
        //הוספת מנה
        public static bool AddRation(Rations ration)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Rations.Add(ration);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון מספר נקודות הדרוג
        public static bool UpdateScoreOfRation(int codeRation, int score)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Rations.FirstOrDefault(code => code.CodeRation == codeRation).ScoreOfRation = score;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון הכמות מהמנה
        public static bool UpdateAmountRation(int codeRation,int plus)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Rations.FirstOrDefault(code => code.CodeRation == codeRation).AmountRation -= plus;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static bool UpdateAmount(int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.Rations.FirstOrDefault(code => code.CodeRation == codeRation);
                    answer.AmountRation = answer.OldAmountRation;
                    answer.DateUpdateAmount = DateTime.Today;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון פרטי מנה
        public static bool UpdateRation(Rations ration)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.Rations.FirstOrDefault(code => code.CodeRation == ration.CodeRation);
                    answer.NameRation = ration.NameRation;
                    answer.PriceRation = ration.PriceRation;
                    answer.CodeCategory = ration.CodeCategory;
                    answer.ContainRation = ration.ContainRation;
                    answer.DairyOrNot = ration.DairyOrNot;
                    answer.ScoreOfRation = ration.ScoreOfRation;
                    answer.AmountRation= ration.AmountRation;
                    answer.OldAmountRation = ration.OldAmountRation;
                    answer.DateUpdateAmount = ration.DateUpdateAmount;
                    answer.PictureRation = ration.PictureRation;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל המנות
        public static List<Rations> GetAllRations()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מחיר מנה לפי קוד מנה
        public static int GetScoreRation(int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.FirstOrDefault(id => id.CodeRation == codeRation);
                    if (temp != null)
                    {
                        return temp.ScoreOfRation;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת מחיר מנה לפי קוד מנה
        public static decimal GetPriceRationByCode(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.FirstOrDefault(id => id.CodeRation == code).PriceRation;
                    return temp;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        //שליפת מנה לפי חלבי או לא
        public static List<Rations> GetRationsByDairyOrNot(bool isDairy)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.Where(dairy => dairy.DairyOrNot == isDairy).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד מנה לפי שם מנה
        public static int GetCodeRationByName(string nameRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.FirstOrDefault(name => name.NameRation == nameRation);
                    if (temp != null)
                    {
                        return temp.CodeRation;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת כל המנות שמספר נקודות הדרוג שלהם בין 2 הנתונים שנשלחו 
        public static List<Rations> GetAllRationsByScoreOfRationsBetween(int start, int finish)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.ToList();
                    List<Rations> answer = new List<Rations>();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if ((int)(temp[i].ScoreOfRation) >= start && (int)(temp[i].ScoreOfRation) <= finish)
                        {
                            answer.Add(temp[i]);
                        }
                    }
                    return answer;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כל המנות שמחירם בין 2 הנתונים שנשלחו
        public static List<Rations> GetAllRationsByPriceOfRationsBetween(int start, int finish)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.ToList();
                    List<Rations> answer = new List<Rations>();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if ((int)(temp[i].PriceRation) >= start && (int)(temp[i].PriceRation) <= finish)
                        {
                            answer.Add(temp[i]);
                        }
                    }
                    return answer;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת מחיר המנה לפי קוד מנה
        public static decimal GetPriceOfRationsByCode(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.FirstOrDefault(id => id.CodeRation == code);
                    if (temp != null)
                    {
                        return temp.PriceRation;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת מנה לפי קוד מנה
        public static Rations GetRationsByCode(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.FirstOrDefault(id => id.CodeRation == code);
                    if (temp != null)
                    {
                        return temp;
                    }
                    return null;
                }
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
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.ToList();
                    var answer = new List<string>();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        answer.Add(temp[i].NameRation);
                    }
                    return answer;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מנות לפי שם קטגוריה
        public static List<Rations> GetRationsByCategory(string name)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var code = FoodCategoryDAL.GetCodeFoodCategoryByName(name);
                    var temp = DB.Rations.Where(ration => ration.CodeCategory == code).ToList();
                    return temp;
                }

            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מנה לפי שם המנה
        public static List<Rations> GetRationsByNameRations(string name)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Rations.Where(ration => ration.NameRation == name).ToList();
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

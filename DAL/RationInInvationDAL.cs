using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RationInInvationDAL
    {
        //הוספת מנה בהזמנה
        public static RationInInvitation AddRationInInvitation(RationInInvitation rationInInvitation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.RationInInvitation.Add(rationInInvitation);
                    DB.SaveChanges();
                    return rationInInvitation;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //מחיקת מנה בהזמנה
        public static bool DeleteRationInInvitation(int codeRationInInvitation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var delete = DB.RationInInvitation.FirstOrDefault(code => code.CodeRationInvitation == codeRationInInvitation);
                    DB.RationInInvitation.Remove(delete);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static List<RationInInvitation> GetAllRationInInvation(int codeInvitation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.Where(code => code.CodeInvitation == codeInvitation).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת קוד מנה לפי מספר הזמנה
        public static int CeckRationExist(int codeInvitation, int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.FirstOrDefault(id => (id.CodeInvitation == codeInvitation) && (id.CodeRation == codeRation));
                    if (temp != null)
                    {
                        return temp.CodeRationInvitation;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת כל המנות בהזמנה מסוימת
        public static List<RationInInvitation> GetAllRationsByCode(int codeInvitation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.Where(code => code.CodeInvitation == codeInvitation).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת ההזמנות שלא בוצעו
        public static List<RationInInvitation> GetRationInInvationsThatNotPerformed()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.Where(performed => performed.IsPerformed == false).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //עדכון הזמנה לבוצעה
        public static bool UpdateRationInInvationsToPerformed(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.RationInInvitation.FirstOrDefault(performed => performed.CodeInvitation == code).IsPerformed = true;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
        
        //שליפת מחיר מנה
        public static decimal GetPricePerServing(int codeInvitation, int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.FirstOrDefault(price => (price.CodeInvitation == codeInvitation) && (price.CodeRation == codeRation));
                    if (temp != null)
                    {
                        return temp.PricePerServing;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        
        //שליפת הכמות המוזמנת מהמנה
        public static int GetAmountRation(int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.RationInInvitation.FirstOrDefault(name => name.CodeRation == codeRation);
                    if (temp != null)
                    {
                        return temp.AmountRation;
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

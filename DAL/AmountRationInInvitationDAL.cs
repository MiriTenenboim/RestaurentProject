using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AmountRationInInvitationDAL
    {
        //הוספת כמות למנה מסוימת
        public static bool AddAmountToRation(int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.AmountRationInInvitation.FirstOrDefault(code => code.CodeRation == codeRation);
                    if (temp != null)
                    {
                        temp.AmountRationInvitation = temp.AmountRationInvitation + 1;
                        DB.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל כמויות המנות
        public static List<AmountRationInInvitation> GetAllAmounts()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.AmountRationInInvitation.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כמות ממנה מסוימת לפי קוד מנה
        public static int GetAmountRationByCode(int codeRation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.AmountRationInInvitation.FirstOrDefault(id => id.CodeRation == codeRation);
                    if (temp != null)
                        return temp.AmountRationInvitation;
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

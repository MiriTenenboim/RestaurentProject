using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvationsDAL
    {
        //הוספת הזמנה
        public static bool AddInvitation(Invitations invitation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Invitations.Add(invitation);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        //עדכון הזמנה לשולם
        public static bool UpdateInvitationToPaid(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.Invitations.FirstOrDefault(paid => paid.CodeInvitation == code);
                    answer.PaidOrUnpaid = true;
                    answer.PaymentMethod = "כרטיס אשראי";
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        // עדכון מחיר הזמנה
        public static bool UpdatePriceToPay(int code, int price)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Invitations.FirstOrDefault(paid => paid.CodeInvitation == code).PriceToPay += price;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל ההזמנות
        public static List<Invitations> GetAllInvations()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Invitations.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת הזמנות מסוימות לפי קוד לקוח
        public static List<Invitations> GetInvitationsByCodeClient(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Invitations.Where(id => id.CodeClient == code).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת קוד לקוח לפי קוד הזמנה
        public static int GetCodeClientByInvitation(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Invitations.FirstOrDefault(id => id.CodeInvitation == code).CodeClient;
                    return temp;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        //שליפת קוד הזמנה לפי קוד לקוח ותאריך
        public static int GetInvitationsByCodeClientAndDate(int code, DateTime date)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Invitations.FirstOrDefault(id => (id.CodeClient == code) && (id.DateInvitation == date));
                    if (temp != null)
                    {
                        return temp.CodeInvitation;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        //שליפת תאריך הזמנה לפי קוד הזמנה
        public static DateTime GetDateOrderByInvitation(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Invitations.FirstOrDefault(id => id.CodeInvitation == code).DateInvitation;
                    return (DateTime)temp;
                }
            }
            catch (Exception error)
            {
                return DateTime.MinValue;
            }
        }

    }
}
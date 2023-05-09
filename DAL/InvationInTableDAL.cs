using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvationInTableDAL
    {
        //הוספת הזמנה בשולחן
        public static bool AddInvitationInTable(InvitationInTable invitationInTable)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.InvitationInTable.Add(invitationInTable);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
        //שליפת כל ההזמנות בשולחנות
        public static List<InvitationInTable> GetAllInvationInTables()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.InvitationInTable.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קודי השולחנות התפוסים
        public static List<int> GetCodeBusyTables()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var busyTables = new List<int>();
                    var temp = DB.InvitationInTable.Where(status => status.StatusTable == true).ToList();
                    foreach (var table in temp)
                    {
                        busyTables.Add(table.CodeTable);
                    }
                    var answer = busyTables.Distinct().ToList();
                    return answer;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת השולחנות התפוסים
        public static List<InvitationInTable> GetBusyTables()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var busyTables = new List<int>();
                    var temp = DB.InvitationInTable.Where(status => status.StatusTable == true).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //עדכון שולחן לפנוי
        public static bool UpdateTableToEmpty(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.InvitationInTable.Where(paid => paid.CodeTable == code).ToList();
                    foreach (var table in answer)
                    {
                        table.StatusTable = false;
                    }
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון שולחן לתפוס
        public static bool UpdateTableToBusy(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.InvitationInTable.Where(paid => paid.CodeTable == code).ToList();
                    foreach (var table in answer)
                    {
                        table.StatusTable = true;
                    }
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}

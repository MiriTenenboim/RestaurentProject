using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDAL
    {
        //שליפת שם התפקיד לפי קוד
        public static string GetNameRoleByCode(int code)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Role.FirstOrDefault(id => id.CodeRole == code);
                    if (temp != null)
                        return temp.KindRole;
                    return null;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

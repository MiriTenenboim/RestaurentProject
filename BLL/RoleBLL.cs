using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class RoleBLL
    {
        //שליפת שם התפקיד לפי קוד
        public static string GetNameRoleByCode(int code)
        {
            try
            {
                return RoleDAL.GetNameRoleByCode(code);
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

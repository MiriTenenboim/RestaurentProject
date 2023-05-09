using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class RoleDTO
    {
        public int CodeRole { get; set; }
        public string KindRole { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static Role ConvertRoleToTable(RoleDTO role)
        {
            Role newRole = new Role();
            try
            {
                newRole.KindRole = role.KindRole;
                return newRole;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<Role> ConvertRoleListToTable(List<RoleDTO> roles)
        {
            List<Role> newRole = new List<Role>();
            try
            {
                foreach (var role in roles)
                {
                    newRole.Add(ConvertRoleToTable(role));
                }
                return newRole;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static RoleDTO ConvertRoleToDTO(Role role)
        {
            RoleDTO newRole = new RoleDTO();
            try
            {
                newRole.KindRole = role.KindRole;
                return newRole;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<RoleDTO> ConvertRoleListToDTO(List<Role> roles)
        {
            List<RoleDTO> newRole = new List<RoleDTO>();
            try
            {
                foreach (var role in roles)
                {
                    newRole.Add(ConvertRoleToDTO(role));
                }
                return newRole;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
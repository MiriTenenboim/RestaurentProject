using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClientsDAL
    {
        //הוספת לקוח חדש
        public static Clients AddClient(Clients client)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Clients.Add(client);
                    DB.SaveChanges();
                    return client;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת כל הלקוחות
        public static List<Clients> GetAllClients()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Clients.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת קוד לקוח מסוים לפי שם ומספר פלאפון
        public static int GetCodeClientByNamePhone(string name, string phone)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Clients.FirstOrDefault(id => (id.NameClient == name) && (id.NumberPhoneClient == phone));
                    if (temp != null)
                        return temp.CodeClient;
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת לקוח מסוים לפי שם ומספר פלאפון
        public static Clients GetClientByNamePhone(string name, string phone)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Clients.FirstOrDefault(id => (id.NameClient == name) && (id.NumberPhoneClient == phone));
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

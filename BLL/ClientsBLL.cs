using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ClientsBLL
    {
        //הוספת לקוח חדש
        public static ClientsDTO AddClient(string nameClient, string familyNameClient, string numberPhoneClient, string emailAdressClient)
        {
            try
            {
                var checkExist = GetCodeClientByNamePhone(nameClient, numberPhoneClient);
                if (checkExist == 0)
                {
                    ClientsDTO newClient = new ClientsDTO();
                    newClient.NameClient = nameClient;
                    newClient.FamilyNameClient = familyNameClient;
                    newClient.NumberPhoneClient = numberPhoneClient;
                    newClient.EmailAdressClient = emailAdressClient;
                    newClient.CodeRole = 2;
                    ClientsDAL.AddClient(ClientsDTO.ConvertClientToTable(newClient));
                    return newClient;
                }
                return null;
            }
            catch (Exception error)
            {
                return null;
            }
        }
        //שליפת כל הלקוחות
        public static List<ClientsDTO> GetAllClients()
        {
            try
            {
                return ClientsDTO.ConvertClientListToDTO(ClientsDAL.GetAllClients());
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
                return ClientsDAL.GetCodeClientByNamePhone(name, phone);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת לקוח מסוים לפי שם ומספר פלאפון
        public static ClientsDTO GetClientByNamePhone(string name, string phone)
        {
            try
            {
                var exist = ClientsDAL.GetClientByNamePhone(name, phone);
                if (exist != null)
                {
                    return ClientsDTO.ConvertClientToDTO(exist);
                }
                return null;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

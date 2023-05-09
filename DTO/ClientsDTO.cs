using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class ClientsDTO
    {
        public int CodeClient { get; set; }
        public string NameClient { get; set; }
        public string FamilyNameClient { get; set; }
        public string NumberPhoneClient { get; set; }
        public string EmailAdressClient { get; set; }
        public int CodeRole { get; set; }


        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static Clients ConvertClientToTable(ClientsDTO client)
        {
            Clients newClient = new Clients();
            try
            {
                newClient.NameClient = client.NameClient;
                newClient.FamilyNameClient = client.FamilyNameClient;
                newClient.NumberPhoneClient = client.NumberPhoneClient;
                newClient.EmailAdressClient = client.EmailAdressClient;
                newClient.CodeRole = client.CodeRole;
                return newClient;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<Clients> ConvertClientListToTable(List<ClientsDTO> clients)
        {
            List<Clients> newClients = new List<Clients>();
            try
            {
                foreach (var client in clients)
                {
                    newClients.Add(ConvertClientToTable(client));
                }
                return newClients;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static ClientsDTO ConvertClientToDTO(Clients client)
        { 
            ClientsDTO newClient = new ClientsDTO();
            try
            {
                newClient.NameClient = client.NameClient;
                newClient.FamilyNameClient = client.FamilyNameClient;
                newClient.NumberPhoneClient = client.NumberPhoneClient;
                newClient.EmailAdressClient = client.EmailAdressClient; 
                newClient.CodeRole = client.CodeRole;
                return newClient;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<ClientsDTO> ConvertClientListToDTO(List<Clients> clients)
        {
            List<ClientsDTO> newClients = new List<ClientsDTO>();
            try
            {
                foreach (var client in clients)
                {
                    newClients.Add(ConvertClientToDTO(client));
                }
                return newClients;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

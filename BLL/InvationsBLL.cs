using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class InvationsBLL
    {
        //הוספת הזמנה
        public static int AddInvitation(string nameClient,string phone)
        {
            try
            {
                InvationsDTO newInvation = new InvationsDTO();
                //שליפת קוד הלקוח שמזמין
                var codeClient = ClientsBLL.GetCodeClientByNamePhone(nameClient,phone); //SESSION STORAGEלשלוח את הנתונים מה
                newInvation.DateInvitation = DateTime.Today.Date;
                newInvation.CodeClient = codeClient;
                newInvation.PriceToPay = 0;
                newInvation.PaymentMethod = "none";
                newInvation.PaidOrUnpaid = false;
                InvationsDAL.AddInvitation(InvationsDTO.ConvertInvationToTable(newInvation));
                var codeInvitation = GetCodeInvitationByCodeClientAndDate(codeClient,newInvation.DateInvitation);
                return codeInvitation;
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //עדכון הזמנה לשולם
        public static bool UpdateInvitationToPaid(int code)
        {
            try
            {
                return InvationsDAL.UpdateInvitationToPaid(code);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static bool UpdatePriceToPay(int code,int price)
        {
            try
            {
                return InvationsDAL.UpdatePriceToPay(code, price);
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל ההזמנות
        public static List<InvationsDTO> GetAllInvitations()
        {
            try
            {
                return InvationsDTO.ConvertInvationListToDTO(InvationsDAL.GetAllInvations());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד הזמנה לפי קוד לקוח ותאריך
        public static int GetCodeInvitationByCodeClientAndDate(int code, DateTime date)
        {
            try
            {
                return InvationsDAL.GetInvitationsByCodeClientAndDate(code, date);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        //שליפת קוד לקוח לפי קוד הזמנה
        public static int GetCodeClientByInvitation(int code)
        {
            try
            {
                return InvationsDAL.GetCodeClientByInvitation(code);
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
                return InvationsDAL.GetDateOrderByInvitation(code);
            }
            catch (Exception error)
            {
                return DateTime.MinValue;
            }
        }
    }
}
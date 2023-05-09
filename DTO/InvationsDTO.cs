using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class InvationsDTO
    {
        public int CodeInvitation { get; set; }
        public System.DateTime DateInvitation { get; set; }
        public int CodeClient { get; set; }
        public int PriceToPay { get; set; }
        public string PaymentMethod { get; set; }
        public bool PaidOrUnpaid { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static Invitations ConvertInvationToTable(InvationsDTO invation)
        {
            try
            {
                Invitations newInvitation = new Invitations();
                newInvitation.CodeInvitation = invation.CodeInvitation;
                newInvitation.DateInvitation = invation.DateInvitation;
                newInvitation.CodeClient = invation.CodeClient;
                newInvitation.PriceToPay = invation.PriceToPay;
                newInvitation.PaymentMethod = invation.PaymentMethod;
                newInvitation.PaidOrUnpaid = invation.PaidOrUnpaid;
                return newInvitation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<Invitations> ConvertInvationListToTable(List<InvationsDTO> Invitations)
        {
            List<Invitations> newInvitations = new List<Invitations>();
            try
            {
                foreach (var invation in Invitations)
                {
                    newInvitations.Add(ConvertInvationToTable(invation));
                }
                return newInvitations;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static InvationsDTO ConvertInvationToDTO(Invitations invation)
        {
            InvationsDTO newInvitation = new InvationsDTO();
            try
            {
                newInvitation.CodeInvitation = invation.CodeInvitation;
                newInvitation.DateInvitation = (DateTime)invation.DateInvitation;
                newInvitation.CodeClient = invation.CodeClient;
                newInvitation.PriceToPay = (int)invation.PriceToPay;
                newInvitation.PaymentMethod = invation.PaymentMethod;
                newInvitation.PaidOrUnpaid = invation.PaidOrUnpaid;
                return newInvitation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<InvationsDTO> ConvertInvationListToDTO(List<Invitations> Invitations)
        {
            List<InvationsDTO> newInvitations = new List<InvationsDTO>();
            try
            {
                foreach (var invation in Invitations)
                {
                    newInvitations.Add(ConvertInvationToDTO(invation));
                }
                return newInvitations;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
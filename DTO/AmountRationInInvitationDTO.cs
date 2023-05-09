using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class AmountRationInInvitationDTO
    {
        public int CodeAmountRationInInvitation { get; set; }
        public int CodeRation { get; set; }
        public int AmountRationInInvitation { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static AmountRationInInvitation ConvertAmountToTable(AmountRationInInvitationDTO amount)
        {
            AmountRationInInvitation newAmount = new AmountRationInInvitation();
            try
            {
                newAmount.CodeRation = amount.CodeRation;
                newAmount.AmountRationInvitation = amount.AmountRationInInvitation;
                return newAmount;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<AmountRationInInvitation> ConvertAmountListToTable(List<AmountRationInInvitationDTO> amounts)
        {
            List<AmountRationInInvitation> newAmount = new List<AmountRationInInvitation>();
            try
            {
                foreach (var amount in amounts)
                {
                    newAmount.Add(ConvertAmountToTable(amount));
                }
                return newAmount;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static AmountRationInInvitationDTO ConvertAmountToDTO(AmountRationInInvitation amount)
        {
            AmountRationInInvitationDTO newAmount = new AmountRationInInvitationDTO();
            try
            {
                newAmount.CodeRation = amount.CodeRation;
                newAmount.AmountRationInInvitation = amount.AmountRationInvitation;
                return newAmount;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<AmountRationInInvitationDTO> ConvertAmountListToDTO(List<AmountRationInInvitation> amounts)
        {
            List<AmountRationInInvitationDTO> newAmount = new List<AmountRationInInvitationDTO>();
            try
            {
                foreach (var amount in amounts)
                {
                    newAmount.Add(ConvertAmountToDTO(amount));
                }
                return newAmount;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
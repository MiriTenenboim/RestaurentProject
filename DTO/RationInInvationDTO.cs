using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class RationInInvationDTO
    {
        public int CodeRationInvitation { get; set; }
        public int CodeInvitation { get; set; }
        public int CodeRation { get; set; }
        public int AmountRation { get; set; }
        public int PricePerServing { get; set; }
        public bool IsPerformed { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static RationInInvitation ConvertRationInInvitationToTable(RationInInvationDTO rationInInvation)
        {
            RationInInvitation newRationInInvation = new RationInInvitation();
            try
            {
                newRationInInvation.CodeRationInvitation = rationInInvation.CodeRationInvitation;
                newRationInInvation.CodeInvitation = rationInInvation.CodeInvitation;
                newRationInInvation.CodeRation = rationInInvation.CodeRation;
                newRationInInvation.AmountRation = rationInInvation.AmountRation;
                newRationInInvation.PricePerServing = rationInInvation.PricePerServing;
                newRationInInvation.IsPerformed = rationInInvation.IsPerformed;
                return newRationInInvation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<RationInInvitation> ConvertRationInInvitationListToTable(List<RationInInvationDTO> rationInInvations)
        {
            List<RationInInvitation> newRationInInvitation = new List<RationInInvitation>();
            try
            {
                foreach (var rationInInvation in rationInInvations)
                {
                    newRationInInvitation.Add(ConvertRationInInvitationToTable(rationInInvation));
                }
                return newRationInInvitation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static RationInInvationDTO ConvertRationInInvitationToDTO(RationInInvitation rationInInvation)
        {
            RationInInvationDTO newRationInInvation = new RationInInvationDTO();
            try
            {
                newRationInInvation.CodeRationInvitation = rationInInvation.CodeRationInvitation;
                newRationInInvation.CodeInvitation = rationInInvation.CodeInvitation;
                newRationInInvation.CodeRation = rationInInvation.CodeRation;
                newRationInInvation.AmountRation = rationInInvation.AmountRation;
                newRationInInvation.PricePerServing = (int)rationInInvation.PricePerServing;
                newRationInInvation.IsPerformed = rationInInvation.IsPerformed;
                return newRationInInvation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<RationInInvationDTO> ConvertRationInInvitationListToDTO(List<RationInInvitation> rationInInvations)
        {
            List<RationInInvationDTO> newRationInInvitation = new List<RationInInvationDTO>();
            try
            {
                foreach (var rationInInvation in rationInInvations)
                {
                    newRationInInvitation.Add(ConvertRationInInvitationToDTO(rationInInvation));
                }
                return newRationInInvitation;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
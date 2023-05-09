using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RationInInvationBLL
    {
        //הוספת מנה בהזמנה
        public static RationInInvationDTO AddRationInInvation(RationInInvationDTO rationInInvation, string nameRation)
        {
            try
            {
                //שליפת קוד המנה לפי שם המנה
                var codeRation = RationsBLL.GetCodeRationsByName(nameRation);
                //מחיר המנה הנוכחית המוזמנת
                var PricePerOrder = RationsBLL.GetPriceOfRationsByCode(codeRation);
                //מחיר ההזמנה הנוכחית: מחיר המנה * הכמות המוזמנת
                PricePerOrder = PricePerOrder * rationInInvation.AmountRation;
                rationInInvation.CodeRation = codeRation;
                rationInInvation.PricePerServing = (int)PricePerOrder;
                RationInInvationDAL.AddRationInInvitation(RationInInvationDTO.ConvertRationInInvitationToTable(rationInInvation));
                return rationInInvation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //מחיקת מנה בהזמנה
        public static bool DeleteRationInInvitation(int codeInvitation, string nameRation)
        {
            try
            {
                var codeRation = RationsBLL.GetCodeRationsByName(nameRation);
                var isExist = CeckRationExist(codeInvitation, codeRation);
                if (isExist != 0)
                {
                    return RationInInvationDAL.DeleteRationInInvitation(isExist);
                }
                return false;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל המנות בהזמנה מסוימת
        public static List<RationsDTO> GetAllRationInInvation(int codeInvitation)
        {
            try
            {
                var rations = RationInInvationDTO.ConvertRationInInvitationListToDTO(RationInInvationDAL.GetAllRationInInvation(codeInvitation));
                List<RationsDTO> allRations = new List<RationsDTO>();
                foreach (var ration in rations)
                {
                    var addRation = RationsBLL.GetRationsByCode(ration.CodeRation);
                    allRations.Add(addRation);
                }
                return allRations;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //בדיקה אם מנה קיימת בהזמנה מסוימת
        public static int CeckRationExist(int codeInvitation, int codeRation)
        {
            try
            {
                return RationInInvationDAL.CeckRationExist(codeInvitation, codeRation);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        //שליפת המנות בהזמנה מסוימת
        public static List<RationInInvationDTO> GetAllRationsByCode(int codeInvitation)
        {
            try
            {
                return RationInInvationDTO.ConvertRationInInvitationListToDTO(RationInInvationDAL.GetAllRationsByCode(codeInvitation));
            }
            catch (Exception error)
            {
                return null;
            }
        }
        
        //שליפת המנות בהזמנה שלא בוצעו
        public static List<RationInInvationDTO> GetRationInInvationsThatNotPerformed()
        {
            try
            {
                return RationInInvationDTO.ConvertRationInInvitationListToDTO(RationInInvationDAL.GetRationInInvationsThatNotPerformed());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מחיר מנה
        public static decimal GetPricePerServing(int codeInvitation,int codeRation)
        {
            try
            {
                return RationInInvationDAL.GetPricePerServing(codeInvitation,codeRation);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת הכמות המוזמנת מהמנה
        public static int GetAmountRation(string nameRation)
        {
            try
            {
                var codeRation = RationsBLL.GetCodeRationsByName(nameRation);
                return RationInInvationDAL.GetAmountRation(codeRation);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class AmountRationInInvitationBLL
    {
        //הוספת כמות למנה מסוימת
        public static bool AddAmountToRation(int codeRation)
        {
            try
            {
                if (codeRation != 0)
                {
                    AmountRationInInvitationDAL.AddAmountToRation(codeRation);
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל הכמויות של המנות
        public static List<AmountRationInInvitationDTO> GetAllAmounts()
        {
            try
            {
                return AmountRationInInvitationDTO.ConvertAmountListToDTO(AmountRationInInvitationDAL.GetAllAmounts());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כמות ממנה מסוימת לפי קוד מנה
        public static int GetAmountRationByCode(int codeRation)
        {
            try
            {
                return AmountRationInInvitationDAL.GetAmountRationByCode(codeRation);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RateRationsBLL
    {
        //הוספת דרוג למנה
        public static RateRationsDTO AddRateRation(RateRationsDTO rateRation, string nameClient, string nameRation, string numberPhoneClient)
        {
            try
            {
                var codeClient = ClientsDAL.GetCodeClientByNamePhone(nameClient, numberPhoneClient);
                if (codeClient != 0)
                {
                    var codeRation = RationsDAL.GetCodeRationByName(nameRation);
                    if (codeRation != 0)
                    {
                        rateRation.CodeClient = codeClient;
                        rateRation.CodeRation = codeRation;
                        RateRationsDAL.AddRateRation(RateRationsDTO.ConvertRateRationToTable(rateRation));
                        //עדכון מספר נקודות הדרוג
                        RationsBLL.UpdateScoreOfRation(codeRation, rateRation.ScoreOfRation);
                        return rateRation;
                    }
                }
                return null;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כל הדרוגים למנות
        public static List<RateRationsDTO> GetAllRateRations()
        {
            try
            {
                return RateRationsDTO.ConvertRateRationListToDTO(RateRationsDAL.GetAllRateRations());
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

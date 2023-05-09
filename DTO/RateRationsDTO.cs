using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class RateRationsDTO
    {
        public int CodeRateRation { get; set; }
        public int CodeClient { get; set; }
        public int CodeRation { get; set; }
        public int ScoreOfRation { get; set; }
        public string Comments { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static RateRations ConvertRateRationToTable(RateRationsDTO rateRations)
        {
            RateRations newRateRation = new RateRations();
            try
            {
                newRateRation.CodeRateRation = rateRations.CodeRateRation;
                newRateRation.CodeClient = rateRations.CodeClient;
                newRateRation.CodeRation = rateRations.CodeRation;
                newRateRation.ScoreOfRation = rateRations.ScoreOfRation;
                newRateRation.Comments = rateRations.Comments;
                return newRateRation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<RateRations> ConvertRateRationListToTable(List<RateRationsDTO> rateRations)
        {
            List<RateRations> newRateRations = new List<RateRations>();
            try
            {
                foreach (var rateRation in rateRations)
                {
                    newRateRations.Add(ConvertRateRationToTable(rateRation));
                }
                return newRateRations;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static RateRationsDTO ConvertRateRationToDTO(RateRations rateRations)
        {
            RateRationsDTO newRateRation = new RateRationsDTO();
            try
            {
                newRateRation.CodeRateRation = rateRations.CodeRateRation;
                newRateRation.CodeClient = rateRations.CodeClient;
                newRateRation.CodeRation = rateRations.CodeRation;
                newRateRation.ScoreOfRation = rateRations.ScoreOfRation;
                newRateRation.Comments = rateRations.Comments;
                return newRateRation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<RateRationsDTO> ConvertRateRationListToDTO(List<RateRations> rateRations)
        {
            List<RateRationsDTO> newRateRations = new List<RateRationsDTO>();
            try
            {
                foreach (var rateRation in rateRations)
                {
                    newRateRations.Add(ConvertRateRationToDTO(rateRation));
                }
                return newRateRations;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
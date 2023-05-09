using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class RationsDTO
    {
        public int CodeRation { get; set; }
        public string NameRation { get; set; }
        public int PriceRation { get; set; }
        public int CodeCategory { get; set; }
        public string ContainRation { get; set; }
        public bool DairyOrNot { get; set; }
        public int ScoreOfRation { get; set; }
        public int AmountRation { get; set; }
        public int OldAmountRation { get; set; }
        public DateTime DateUpdateAmount { get; set; }
        public string PictureRation { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static Rations ConvertRationToTable(RationsDTO ration)
        {
            Rations newRation = new Rations();
            try
            {
                newRation.CodeRation = ration.CodeRation;
                newRation.NameRation = ration.NameRation;
                newRation.PriceRation = ration.PriceRation;
                newRation.CodeCategory = ration.CodeCategory;
                newRation.ContainRation = ration.ContainRation;
                newRation.DairyOrNot = ration.DairyOrNot;
                newRation.ScoreOfRation = ration.ScoreOfRation;
                newRation.AmountRation = ration.AmountRation;
                newRation.OldAmountRation = ration.OldAmountRation;
                newRation.DateUpdateAmount = ration.DateUpdateAmount;
                newRation.PictureRation = ration.PictureRation;
                return newRation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<Rations> ConvertRationListToTable(List<RationsDTO> rations)
        {
            List<Rations> newRations = new List<Rations>();
            try
            {
                foreach (var ration in rations)
                {
                    newRations.Add(ConvertRationToTable(ration));
                }
                return newRations;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static RationsDTO ConvertRationToDTO(Rations ration)
        {
            RationsDTO newRation = new RationsDTO();
            try
            {
                newRation.CodeRation = ration.CodeRation;
                newRation.NameRation = ration.NameRation;
                newRation.PriceRation = (int)ration.PriceRation;
                newRation.CodeCategory = ration.CodeCategory;
                newRation.ContainRation = ration.ContainRation;
                newRation.DairyOrNot = ration.DairyOrNot;
                newRation.ScoreOfRation = ration.ScoreOfRation;
                newRation.AmountRation = ration.AmountRation;
                newRation.OldAmountRation = ration.OldAmountRation;
                newRation.DateUpdateAmount = (DateTime)ration.DateUpdateAmount;
                newRation.PictureRation = ration.PictureRation;
                return newRation;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<RationsDTO> ConvertRationListToDTO(List<Rations> rations)
        {
            List<RationsDTO> newRations = new List<RationsDTO>();
            try
            {
                foreach (var ration in rations)
                {
                    newRations.Add(ConvertRationToDTO(ration));
                }
                return newRations;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
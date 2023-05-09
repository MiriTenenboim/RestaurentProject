using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class TablesDTO
    {
        public int CodeTable { get; set; }
        public int NumberOfDiners { get; set; }
        public string TableLocation { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static Tables ConvertTableToTable(TablesDTO table)
        {
            Tables newTable = new Tables();
            try
            {
                newTable.CodeTable = table.CodeTable;
                newTable.NumberOfDiners = table.NumberOfDiners;
                newTable.TableLocation = table.TableLocation;
                return newTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<Tables> ConvertTableListToTable(List<TablesDTO> tables)
        {
            List<Tables> newTables = new List<Tables>();
            try
            {
                foreach (var table in tables)
                {
                    newTables.Add(ConvertTableToTable(table));
                }
                return newTables;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static TablesDTO ConvertTableToDTO(Tables table)
        {
            TablesDTO newTable = new TablesDTO();
            try
            {
                newTable.CodeTable = table.CodeTable;
                newTable.NumberOfDiners = table.NumberOfDiners;
                newTable.TableLocation = table.TableLocation;
                return newTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<TablesDTO> ConvertTableListToDTO(List<Tables> tables)
        {
            List<TablesDTO> newTables = new List<TablesDTO>();
            try
            {
                foreach (var table in tables)
                {
                    newTables.Add(ConvertTableToDTO(table));
                }
                return newTables;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
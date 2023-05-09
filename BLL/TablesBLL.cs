using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TablesBLL
    {
        //הוספת שולחן חדש
        public static bool AddTable(string tableLocation, int numDiners)
        {
            try
            {
                var table = GetTableByLocation(tableLocation);
                TablesDTO newTable = new TablesDTO();
                newTable.NumberOfDiners = numDiners;
                newTable.TableLocation = tableLocation;
                if (table.Count == 0)
                {
                    TablesDAL.AddTable(TablesDTO.ConvertTableToTable(newTable));
                    return true;
                }
                //עדכון פרטי השולחן
                UpdateTable(newTable);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static bool UpdateTable(TablesDTO table)
        {
            try
            {
                return TablesDAL.UpdateTable(TablesDTO.ConvertTableToTable(table));
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל השולחנות
        public static List<TablesDTO> GetAllTables()
        {
            try
            {
                return TablesDTO.ConvertTableListToDTO(TablesDAL.GetAllTables());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כל המיקומים של השולחנות
        public static List<string> GetFreeLocation()
        {
            try
            {
                var tables = GetFreeTables();
                List<string> answer = new List<string>();
                for (int i = 0; i < tables.Count; i++)
                {
                    answer.Add(tables[i].TableLocation);
                }
                return answer;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת כל המיקומים של השולחנות התפוסים
        public static List<string> GetBusyLocation()
        {
            try
            {
                var tables = InvationInTableBLL.GetBusyTables();
                List<int> answer = new List<int>();
                List<string> allLocations = new List<string>();
                for (int i = 0; i < tables.Count; i++)
                {
                    answer.Add(tables[i].CodeTable);
                }
                var codes = answer.Distinct().ToList();
                for (int i = 0; i < codes.Count; i++)
                {
                     allLocations.Add(GetLocationByCode(codes[i]));
                }
                return allLocations;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד שולחן לפי מיקום
        public static List<TablesDTO> GetTableByLocation(string location)
        {
            try
            {
                return TablesDTO.ConvertTableListToDTO(TablesDAL.GetTableByLocation(location));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד שולחן לפי מיקום
        public static int GetCodeTableByLocation(string location)
        {
            try
            {
                return TablesDAL.GetCodeTableByLocation(location);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת השולחנות הפנויים
        public static List<TablesDTO> GetFreeTables()
        {
            try
            {
                int count;
                var tables = GetAllTables();
                var busyTables = InvationInTableBLL.GetCodeBusyTables();
                List<TablesDTO> freeTables = new List<TablesDTO>();
                for (int i = 0; i < tables.Count; i++)
                {
                    count = 0;
                    for (int j = 0; j < busyTables.Count; j++)
                    {
                        if (tables[i].CodeTable != busyTables[j])
                        {
                            count++;
                        }
                    }
                    if (count == busyTables.Count)
                    {
                        freeTables.Add(tables[i]);
                    }
                }
                return freeTables;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת השולחנות לפי מספר הסועדים בין 2 המספרים שנשלחו
        public static List<TablesDTO> GetTablesByNumDiners(int min, int max)
        {
            try
            {
                return TablesDTO.ConvertTableListToDTO(TablesDAL.GetTablesByNumDiners(min, max));
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת מיקום שולחן לפי קוד
        public static string GetLocationByCode(int codeTable)
        {
            try
            {
                return TablesDAL.GetLocationByCode(codeTable);
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TablesDAL
    {
        //הוספת שולחן
        public static bool AddTable(Tables table)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    DB.Tables.Add(table);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public static bool UpdateTable(Tables table)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var answer = DB.Tables.FirstOrDefault(location => location.TableLocation == table.TableLocation);
                    answer.NumberOfDiners= table.NumberOfDiners;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל השולחנות
        public static List<Tables> GetAllTables()
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Tables.ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת שולחן לפי מיקום
        public static List<Tables> GetTableByLocation(string tableLocation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Tables.Where(location => location.TableLocation == tableLocation).ToList();
                    return temp;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //שליפת קוד שולחן לפי מיקום
        public static int GetCodeTableByLocation(string tableLocation)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Tables.FirstOrDefault(location => location.TableLocation == tableLocation);
                    if (temp != null)
                    {
                        return temp.CodeTable;
                    }
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        //שליפת השולחנות לפי מספר הסועדים בין 2 המספרים שנשלחו
        public static List<Tables> GetTablesByNumDiners(int min, int max)
        {
            try
            {
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Tables.Where(tables => tables.NumberOfDiners >= min && tables.NumberOfDiners <= max).ToList();
                    return temp;
                }
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
                using (RestaurentEntities DB = new RestaurentEntities())
                {
                    var temp = DB.Tables.FirstOrDefault(tables => tables.CodeTable == codeTable);
                    if (temp != null)
                    {
                        return temp.TableLocation;
                    }
                    return null;
                }
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

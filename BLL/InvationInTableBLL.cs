using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class InvationInTableBLL
    {
        //הוספת הזמנה בשולחן
        public static bool AddInvationInTable(int codeInvitation, string tableLocation)
        {
            try
            {
                var codeTable = TablesBLL.GetCodeTableByLocation(tableLocation);
                InvitationInTableDTO newInvationInTable = new InvitationInTableDTO();
                newInvationInTable.CodeInvitation = codeInvitation;
                newInvationInTable.CodeTable = codeTable;
                newInvationInTable.StatusTable = true;
                UpdateTableToBusy(tableLocation);
                InvationInTableDAL.AddInvitationInTable(InvitationInTableDTO.ConvertInvitationInTableToTable(newInvationInTable));
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        //שליפת כל ההזמנות בשולחנות
        public static List<InvitationInTableDTO> GetAllInvationInTables()
        {
            try
            {
                return InvitationInTableDTO.ConvertInvitationInTableListToDTO(InvationInTableDAL.GetAllInvationInTables());
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //עדכון שולחן לפנוי
        public static bool UpdateTableToEmpty(string tableLocation)
        {
            try
            {
                var codeTable = TablesBLL.GetCodeTableByLocation(tableLocation);
                InvationInTableDAL.UpdateTableToEmpty(codeTable);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //עדכון שולחן לתפוס
        public static bool UpdateTableToBusy(string tableLocation)
        {
            try
            {
                var codeTable = TablesBLL.GetCodeTableByLocation(tableLocation);
                InvationInTableDAL.UpdateTableToBusy(codeTable);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //שליפת כל הקודים של השולחנות התפוסים
        public static List<int> GetCodeBusyTables()
        {
            try
            {
                return InvationInTableDAL.GetCodeBusyTables();
            }
            catch (Exception error)
            {
                return null;
            }
        }

        // שליפת כל השולחנות התפוסים
        public static List<InvitationInTableDTO> GetBusyTables()
        {
            try
            {
                return InvitationInTableDTO.ConvertInvitationInTableListToDTO(InvationInTableDAL.GetBusyTables());
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}

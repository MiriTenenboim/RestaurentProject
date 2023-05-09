using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class InvitationInTableDTO
    {
        public int CodeInvitationInTable { get; set; }
        public int CodeInvitation { get; set; }
        public int CodeTable { get; set; }
        public DateTime OrderHour { get; set; }
        public bool StatusTable { get; set; }

        //המרת אוביקט טבלה לאוביקט של מיקרוסופט 
        public static InvitationInTable ConvertInvitationInTableToTable(InvitationInTableDTO invitationInTable)
        {
            InvitationInTable newInvitationInTable = new InvitationInTable();
            try
            {
                newInvitationInTable.CodeInvitationInTable = invitationInTable.CodeInvitationInTable;
                newInvitationInTable.CodeInvitation = invitationInTable.CodeInvitation;
                newInvitationInTable.CodeTable = invitationInTable.CodeTable;
                newInvitationInTable.OrderHour = invitationInTable.OrderHour;
                newInvitationInTable.StatusTable = invitationInTable.StatusTable;
                return newInvitationInTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים מסוג טבלה לאוביקט של מיקרוסופט 
        public static List<InvitationInTable> ConvertInvitationInTableListToTable(List<InvitationInTableDTO> InvitationInTable)
        {
            List<InvitationInTable> newInvitationInTable = new List<InvitationInTable>();
            try
            {
                foreach (var invitationInTable in InvitationInTable)
                {
                    newInvitationInTable.Add(ConvertInvitationInTableToTable(invitationInTable));
                }
                return newInvitationInTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת אוביקט של מיקרוסופט לאוביקט טבלה 
        public static InvitationInTableDTO ConvertInvitationInTableToDTO(InvitationInTable invitationInTable)
        {
            InvitationInTableDTO newInvitationInTable = new InvitationInTableDTO();
            try
            {
                newInvitationInTable.CodeInvitationInTable = invitationInTable.CodeInvitationInTable;
                newInvitationInTable.CodeInvitation = invitationInTable.CodeInvitation;
                newInvitationInTable.CodeTable = invitationInTable.CodeTable;
                newInvitationInTable.OrderHour = invitationInTable.OrderHour;
                newInvitationInTable.StatusTable = invitationInTable.StatusTable;
                return newInvitationInTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        //המרת מספר אוביקטים של מיקרוסופט לאוביקט טבלה 
        public static List<InvitationInTableDTO> ConvertInvitationInTableListToDTO(List<InvitationInTable> InvitationInTable)
        {
            List<InvitationInTableDTO> newInvitationInTable = new List<InvitationInTableDTO>();
            try
            {
                foreach (var invitationInTable in InvitationInTable)
                {
                    newInvitationInTable.Add(ConvertInvitationInTableToDTO(invitationInTable));
                }
                return newInvitationInTable;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
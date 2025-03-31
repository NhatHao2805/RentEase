using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ContractBLL
    {
        public static DataTable ContractBLL_load_Contract(string Username)
        {
            return ContractAccess.load_Contract(Username);
        } 

        public static string ContractBLL_add_Contract(string HouseAddress,string RoomId, string TenantName, string CreateDate, string StartDate, string EndDate, string PaymenSchedule, string Deposite, string Note)
        {
            if(HouseAddress == "" || RoomId == "" || TenantName == "" || CreateDate == "" || StartDate == "" || EndDate == "" || PaymenSchedule == "" || Deposite == "")
            {
                return "Please fill all the fields";
            }

            return ContractAccess.add_Contract(HouseAddress, RoomId, TenantName, CreateDate, StartDate, EndDate, PaymenSchedule, Deposite, Note);
        }
        public static string ContractBLL_alter_Contract(string contractid)
        {
            return ContractAccess.alter_Contract(contractid);
        }
        public static string ContractBLL_update_Contract(string contractid, string enddate, string paymentschedule, string deposit, string note)
        {
            return ContractAccess.update_Contract(contractid,enddate,paymentschedule,deposit,note);
        }

        public static string ContractBLL_delete_Contract(string contractid)
        {
            return ContractAccess.delete_Contract(contractid);
        }
    }
}

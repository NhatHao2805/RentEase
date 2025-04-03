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
        public static List<string> GetRoomsByTenant(string tenantID)
        {
            return ContractAccess.GetRoomsByTenantID(tenantID);
        }
        public static DataTable ContractBLL_load_Contract(string buildingID)
        {
            return ContractAccess.load_Contract(buildingID);
        } 
        public static DataTable ContractBLL_load_Contract_filter(string buildingID, int control, string name)
        {
            return ContractAccess.load_Contract(buildingID, control,name);
        }
        public static string ContractBLL_add_Contract(string buildingid, string RoomId, string Tenantid, string CreateDate, string StartDate, string EndDate, string PaymenSchedule, string Deposite, string Note)
        {
            if( RoomId == "" || Tenantid == "" || CreateDate == "" || StartDate == "" || EndDate == "" || PaymenSchedule == "" || Deposite == "")
            {
                return "Please fill all the fields";
            }

            return ContractAccess.add_Contract(buildingid, RoomId, Tenantid, CreateDate, StartDate, EndDate, PaymenSchedule, Deposite, Note);
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

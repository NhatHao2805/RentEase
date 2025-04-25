using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.dto_service;
using DAL.dal_service;
using System.Data;
namespace BLL.honhathao
{
    public class W_E_BLL
    {
        public static string W_E_BLL_Del_W_E(string tenantID, string startdate, string enddate)
        {
            return W_E_Access.del_W_E(tenantID, startdate, enddate);
        }
        public static string Add_W_E(string buildingID,string tenantid, string o_w, string n_w, string o_e, string n_e, string month)
        {
            return W_E_Access.add_W_E(buildingID, tenantid, o_w, n_w, o_e, n_e, month);
        }

        public static DataTable W_E_BLL_load_W_E(string usern, string buildingid)
        {
            return W_E_Access.load_W_E(usern,buildingid);
        }
    }

}

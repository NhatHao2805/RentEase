using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class RepairRequestBLL
    {
        private RepairRequestAccess access = new RepairRequestAccess();
        public DataTable GetRepairRequest()
        {
            return access.GetRepairRequest();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class RepairRequestAccess: DatabaseAccess
    {
        private DatabaseAccess database =  new DatabaseAccess();
        public DataTable GetRepairRequest()
        {
            return database.LoadRepairRequest();
        }
    }
}
